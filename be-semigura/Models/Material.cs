using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

[Table("Material")]
public class Material : AuditableEntityBase
{
    [Column(TypeName = "varchar(100)")]
    public string? Name { get; set; }
    [Column(TypeName = "varchar(500)")]
    public string? Note { get; set; }

}
