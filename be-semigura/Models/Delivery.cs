using Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

[Table("Delivery")]
[Index(nameof(Code), IsUnique = true)]
public class Delivery : IEntity
{
    [Key]
    [Column(TypeName = "varchar(32)")]
    public string? Id { get; set; } = ModelsHelper.NewId();

    //拠点コード
    [MaxLength(10)]
    public string? Code { get; set; }

    // 拠点名
    [MaxLength(100)]
    public string? Name { get; set; }
    // 拠点名（かな）
    [MaxLength(100)]
    public string? Name2 { get; set; }
    // 拠点略称
    [MaxLength(100)]
    public string? Short { get; set; }
    // エリア
    [MaxLength(10)]
    public string? Area { get; set; }
    // 住所１
    [MaxLength(100)]
    public string? Address1 { get; set; }
    // 住所2
    [MaxLength(100)]
    public string? Address2 { get; set; }
    // 距離
    public int? Distance { get; set; }
    // 車両制限
    [MaxLength(50)]
    public string? VehicleRestrictions { get; set; }
    // 納入時間1
    // 5:00～8:00
    public TimeSpan? DeliveryStartTime1 { get; set; }
    public TimeSpan? DeliveryEndTime1 { get; set; }
    // 納入時間2
    // 5:00～8:00
    public TimeSpan? DeliveryStartTime2 { get; set; }
    public TimeSpan? DeliveryEndTime2 { get; set; }
    // 納入時間3
    // 5:00～8:00
    public TimeSpan? DeliveryStartTime3 { get; set; }
    public TimeSpan? DeliveryEndTime3 { get; set; }
    // 納入時間4
    // 5:00～8:00
    public TimeSpan? DeliveryStartTime4 { get; set; }
    public TimeSpan? DeliveryEndTime4 { get; set; }
    // 備考
    [MaxLength(250)]
    public string? Note { get; set; }
    // トレーラー
    [MaxLength(50)]
    public string? Trailer { get; set; }
    //トレーラー以外
    [MaxLength(50)]
    public string? NotTrailer { get; set; }
}
