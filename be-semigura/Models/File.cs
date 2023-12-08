using Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

[Table("File")]
public class File : IEntity
{
    [Key]
    [Column(TypeName = "varchar(32)")]
    public string? Id { get; set; } = ModelsHelper.NewId();
    public string? Path { get; set; } = null!;

}

public class FileTypeExtensions : ObjectTypeExtension<File>
{
    protected override void Configure(IObjectTypeDescriptor<File> descriptor)
    {
        _ = descriptor
            .Field("base64")
            .Type<StringType>()
            .Resolve(context =>
            {
                var parent = context.Parent<File>();
                return parent.GetBase64();
            });
    }
}

public static class FileExtensionMethods
{
    public static String? GetBase64(this Models.File file)
    {
        try
        {
            if (file.Path != null && System.IO.File.Exists(file.Path))
            {
                var buffer = System.IO.File.ReadAllBytes(file.Path);
                var base64 = Convert.ToBase64String(buffer);
                return base64;
            }
            else { return null; }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message);
            return null;
        }
    }

    public static String? SaveBase64(this Models.File file, string? base64)
    {
        try
        {
            var savedPath = file.Path;
            if (savedPath != null && base64 != null)
            {
                if (System.IO.File.Exists(savedPath))
                {
                    System.IO.File.Delete(savedPath);
                }
                var buffer = Convert.FromBase64String(base64);
                System.IO.File.WriteAllBytes(savedPath, buffer);
                return savedPath;
            }
            else { return null; }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message);
            return null;
        }
    }
}

