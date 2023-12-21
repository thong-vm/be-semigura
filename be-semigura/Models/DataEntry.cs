using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

[Table("DataEntry")]
public class DataEntry : AuditableEntityBase
{

    [Column(TypeName = "varchar(100)")]
    public string? ContainerId { get; set; }
    [Column(TypeName = "varchar(100)")]
    public string? LotContainerId { get; set; }
    public double? BaumeDegree { get; set; }
    public double? AlcoholDegree { get; set; }
    public double? Acid { get; set; }
    public double? AminoAcid { get; set; }
    public double? Glucose { get; set; }

    [Column(TypeName = "varchar(500)")]
    public string? Note { get; set; }
    public DateTime? MeasureDate { get; set; }
    public Container? Container { get; set; }
    public LotContainer? LotContainer { get; set; }

}
