using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

[Table("LotContainerTerminal")]
public class LotContainerTerminal : AuditableEntityBase
{
    [Column(TypeName = "varchar(100)")]
    public string? LotContainerId { get; set; }
    [Column(TypeName = "varchar(100)")]
    public string? TerminalId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public LotContainer? LotContainer { get; set; }
    public Terminal? Terminal { get; set; }
}
