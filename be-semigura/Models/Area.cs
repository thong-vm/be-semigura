using Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

[Table("Area")]
[Index(nameof(Code), IsUnique = true)]
public class Area : IEntity
{
    public enum ShipCountType
    {
        ONE = 1,
        TW0_OR_MORE = 2,
    }

    [Key]
    [Column(TypeName = "varchar(32)")]
    public string? Id { get; set; } = ModelsHelper.NewId();

    //エリアコード
    [MaxLength(10)]
    public string? Code { get; set; }

    // エリア名
    [MaxLength(20)]
    public string? Name { get; set; }
    // 便数
    // 1回|2回以上
    public ShipCountType? ShipCount { get; set; }
    // エリア作業時間
    // 1, 0.5
    public TimeSpan? DeliveryHours { get; set; }
    // デポから移動時間
    // 4, 0.5
    public TimeSpan? TransferHours { get; set; }
}

