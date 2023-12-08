using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Models;
using Repositories;
using Template;

namespace Controllers;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
public class MultipartFormDataAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var request = context.HttpContext.Request;

        if (request.HasFormContentType
            && request.ContentType != null
            && request.ContentType.StartsWith("multipart/form-data", StringComparison.OrdinalIgnoreCase))
        {
            return;
        }

        context.Result = new StatusCodeResult(StatusCodes.Status415UnsupportedMediaType);
    }
}

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class DisableFormValueModelBindingAttribute : Attribute, IResourceFilter
{
    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        var factories = context.ValueProviderFactories;
        factories.RemoveType<FormValueProviderFactory>();
        factories.RemoveType<FormFileValueProviderFactory>();
        factories.RemoveType<JQueryFormValueProviderFactory>();
    }

    public void OnResourceExecuted(ResourceExecutedContext context)
    {
    }
}

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class FilesController : TController<Models.File, TRepository<Models.File, ApplicationDbContext>>
{
    private readonly FileRepository _repo;

    public FilesController(TRepository<Models.File, ApplicationDbContext> repository) : base(repository)
    {
        _repo = (FileRepository)repository;
    }


    [HttpPost("upload-stream-multipartreader")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
    [MultipartFormData]
    [DisableFormValueModelBinding]
    public async Task<Models.File?> Upload()
    {
        if (Request.ContentType == null) { return null; }

        var fileUploadSummary = await UploadFileAsync(HttpContext.Request.Body, Request.ContentType);
        return await _repo.Add(new Models.File { Path = fileUploadSummary.FilePaths[0] });
    }

    // POST: api/[controller]
    [HttpPost]
    [Route("upload")]
    public async Task<ActionResult<Models.File>> Post()
    {
        var content = HttpContext.Request.Form.Files;
        if (content.Count == 0) { return NoContent(); }

        string? id = HttpContext.Request.Form.ContainsKey("id") ? HttpContext.Request.Form["id"].ToString() : null;
        IFormFile file = content[0];
        var fileName = file.FileName;
        _ = file.Length;

        var savedPath = System.IO.Path.Combine(_repo.GetUploadPath(), fileName);
        if (System.IO.File.Exists(savedPath))
        {
            System.IO.File.Delete(savedPath);
        }

        await using var stream = new FileStream(savedPath, FileMode.Create, FileAccess.Write, FileShare.None, 1024);
        await file.CopyToAsync(stream);

        var newFile = new Models.File();
        newFile.Id = id ?? newFile.Id;
        newFile.Path = savedPath;
        await _repo.Add(newFile);

        return newFile;
    }
    public class FileUploadSummary
    {
        public int TotalFilesUploaded { get; set; } = 0;
        public string TotalSizeUploaded { get; set; } = string.Empty;
        public IList<string> FilePaths { get; set; } = new List<string>();
        public IList<string> NotUploadedFiles { get; set; } = new List<string>();
    }

    public async Task<FileUploadSummary> UploadFileAsync(Stream fileStream, string contentType)
    {
        var fileCount = 0;
        long totalSizeInBytes = 0;

        var boundary = GetBoundary(MediaTypeHeaderValue.Parse(contentType));
        var multipartReader = new MultipartReader(boundary, fileStream);
        var section = await multipartReader.ReadNextSectionAsync();

        var filePaths = new List<string>();
        var notUploadedFiles = new List<string>();

        while (section != null)
        {
            var fileSection = section.AsFileSection();
            if (fileSection != null)
            {
                totalSizeInBytes += await SaveFileAsync(fileSection, filePaths, notUploadedFiles);
                fileCount++;
            }

            section = await multipartReader.ReadNextSectionAsync();
        }

        return new FileUploadSummary
        {
            TotalFilesUploaded = fileCount,
            TotalSizeUploaded = ConvertSizeToString(totalSizeInBytes),
            FilePaths = filePaths,
            NotUploadedFiles = notUploadedFiles
        };
    }
    private async Task<long> SaveFileAsync(FileMultipartSection fileSection, IList<string> filePaths, IList<string> notUploadedFiles)
    {
        var UploadsSubDirectory = _repo.GetUploadPath();
        Directory.CreateDirectory(UploadsSubDirectory);

        var filePath = System.IO.Path.Combine(UploadsSubDirectory, fileSection.FileName);

        await using var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None, 1024);
        if (fileSection.FileStream != null)
        {
            await fileSection.FileStream.CopyToAsync(stream);
            filePaths.Add(GetFullFilePath(fileSection, UploadsSubDirectory));

            return fileSection.FileStream.Length;
        }

        notUploadedFiles.Add(fileSection.FileName);
        return 0;
    }

    private static string GetFullFilePath(FileMultipartSection fileSection, string UploadsSubDirectory)
    {
        return !string.IsNullOrEmpty(fileSection.FileName)
            ? System.IO.Path.Combine(Directory.GetCurrentDirectory(), UploadsSubDirectory, fileSection.FileName)
            : string.Empty;
    }

    private static string ConvertSizeToString(long bytes)
    {
        var fileSize = new decimal(bytes);
        var kilobyte = new decimal(1024);
        var megabyte = new decimal(1024 * 1024);
        var gigabyte = new decimal(1024 * 1024 * 1024);

        return fileSize switch
        {
            _ when fileSize < kilobyte => "Less then 1KB",
            _ when fileSize < megabyte =>
                $"{Math.Round(fileSize / kilobyte, fileSize < 10 * kilobyte ? 2 : 1, MidpointRounding.AwayFromZero):##,###.##}KB",
            _ when fileSize < gigabyte =>
                $"{Math.Round(fileSize / megabyte, fileSize < 10 * megabyte ? 2 : 1, MidpointRounding.AwayFromZero):##,###.##}MB",
            _ when fileSize >= gigabyte =>
                $"{Math.Round(fileSize / gigabyte, fileSize < 10 * gigabyte ? 2 : 1, MidpointRounding.AwayFromZero):##,###.##}GB",
            _ => "n/a"
        };
    }

    private static string GetBoundary(MediaTypeHeaderValue contentType)
    {
        var boundary = HeaderUtilities.RemoveQuotes(contentType.Boundary).Value;

        if (string.IsNullOrWhiteSpace(boundary))
        {
            throw new InvalidDataException("Missing content-type boundary.");
        }

        return boundary;
    }

    [HttpGet]
    [Route("{id}/base64")]
    public async Task<string?> GetBase64(string id)
    {
        var file = await _repo.Get(id).FirstOrDefaultAsync();
        if (file == null) { return null; }
        return file.GetBase64();
    }

    [HttpGet]
    [Route("{id}/text")]
    public async Task<string> GetText(string id)
    {
        var file = await _repo.Get(id).FirstOrDefaultAsync();
        if (file == null || file.Path == null) throw new Exception("Invalid id!");

        var js = System.IO.File.ReadAllText(file.Path);
        return js;
    }
    // PATCH: api/[controller]
    [HttpPatch]
    [Route("{id}/text")]
    public async Task<ActionResult<Models.File>> PatchText(string id)
    {
        var found = await _repo.FindAsync(id);
        if (found == null) { return BadRequest("Invalid id!"); }

        var content = HttpContext.Request.Form.Files;
        if (content.Count == 0) { return BadRequest("No file content!"); }

        IFormFile file = content[0];

        var savedPath = found.Path ?? throw new Exception("Path is null!");

        await using var stream = new FileStream(savedPath, FileMode.Create, FileAccess.Write, FileShare.None, 1024);
        await file.CopyToAsync(stream);
        return found;
    }

}
