using Data;
using Template;

namespace Repositories;

public class FileRepository : TRepository<Models.File, ApplicationDbContext>
{
    private IConfiguration _configuration;
    public FileRepository(ApplicationDbContext context, IConfiguration configuration) : base(context)
    {
        _configuration = configuration;
    }

    public string GetUploadPath()
    {
        return _configuration.GetSection("FileUpload")["Location"];
    }
}
