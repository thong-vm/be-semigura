using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

[Table("Lot")]
public class Lot : AuditableEntityBase
{
    [Column(TypeName = "varchar(100)")]
    public string? Code { get; set; }
    [Column(TypeName = "varchar(100)")]
    public string? FactoryId { get; set; }
    [Column(TypeName = "varchar(100)")]
    public string? MaterialId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? MaterialClassification {  get; set; }
    [Column(TypeName = "varchar(100)")]
    public string? RicePolishingRatioName { get; set; }
    public double? RicePolishingRatio { get; set; }

}
