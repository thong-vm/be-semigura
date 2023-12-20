using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

[Table("SensorData")]
public class SensorData : AuditableEntityBase
{
    [Column(TypeName = "varchar(100)")]
    public string? TerminalId { get; set; }
    [Column(TypeName = "varchar(100)")]
    public string? LotContainerId { get; set; }

    public double? Temperature1 { get; set; }
    public double? Temperature2 { get; set; }
    public double? Temperature3 { get; set; }
    public double? Humidity { get; set; }
    public DateTime? MeasureDate { get; set; }

}
