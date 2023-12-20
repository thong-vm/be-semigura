﻿
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

}
