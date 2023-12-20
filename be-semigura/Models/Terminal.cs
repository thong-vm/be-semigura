using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

[Table("Terminal")]
public class Terminal : AuditableEntityBase
{
    [Column(TypeName = "varchar(100)")]
    public string? Code { get; set; }
    [Column(TypeName = "varchar(100)")]
    public string? Name { get; set; }
    public int? Type { get; set; }

    [Column(TypeName = "varchar(100)")]
    public string? ParentId { get; set; }
    [Column(TypeName = "varchar(100)")]
    public string? LoginId { get; set; }
    [Column(TypeName = "varchar(100)")]
    public string? Password { get; set; }
    public Boolean? DeleteFlg { get; set; }

}
