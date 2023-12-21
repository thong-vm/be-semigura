using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

[Table("Container")]
public class Container : AuditableEntityBase
{

    [Column(TypeName = "varchar(100)")]
    public string? Code { get; set; }
    [Column(TypeName = "varchar(100)")]
    public string? LocationId { get; set; }
    public int? Type { get; set; }
    public double? Capacity { get; set; }
    public double? Height { get; set; }
    public Boolean? DeleteFlg { get; set; }
    public List<LotContainer>? LotContainers { get; set; }
    public be_semigura.Models.Location? Location { get; set; }

}
