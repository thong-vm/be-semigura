using Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

[Table("Truck")]
[Index(nameof(Code), IsUnique = true)]
public class Truck : IEntity
{
    public enum TruckType
    {
        Small,
        Medium,
        Large,
    }
    public enum TruckSize
    {
        TS_8TON,
        TS_12TON,
        TS_15TON,
        TS_TRAILER,
    }

    [Key]
    [Column(TypeName = "varchar(32)")]
    public string? Id { get; set; } = ModelsHelper.NewId();

    // トラックコード
    // 000887
    [MaxLength(10)]
    public string? Code { get; set; }

    // 車格
    [MaxLength(20)]
    public string? Name { get; set; }
    // 最大積載量
    public int? Capacity { get; set; }
    // 開始時間
    // 05:00:00
    public TimeSpan? StartTime { get; set; }
    // 終了時間
    // 05:00:00
    public TimeSpan? EndTime { get; set; }
    // 運転手名
    [MaxLength(50)]
    public string? DriverName { get; set; }
    // 単価
    // 小型|中型|大型
    public TruckType? Type { get; set; }
    // 車格グループ
    // 8t|トレーラ
    public TruckSize? Size { get; set; }
    // 利用
    // 有|無
    public bool? Used { get; set; }
}

