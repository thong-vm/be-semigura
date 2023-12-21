
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

[Table("LotContainer")]
public class LotContainer : AuditableEntityBase
{
    [Column(TypeName = "varchar(100)")]
    public string? LotId { get; set; }

    [Column(TypeName = "varchar(100)")]
    public string? LocationId { get; set; }
    [Column(TypeName = "varchar(100)")]
    public string? ContainerId { get; set; }

    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public double? TempMin { get; set; }
    public double? TempMax { get; set; }
    [Column(TypeName = "varchar(500)")]
    public string? Note { get; set; }
    public List<SensorData>? SensorDatas { get; set; }
    public List<LotContainerTerminal>? LotContainerTerminals { get; set; }
    public Lot? Lot { get; set; }
    public Container? Container { get; set; }
    public be_semigura.Models.Location? Location { get; set; }

}
