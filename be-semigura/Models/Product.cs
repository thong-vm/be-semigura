using Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

[Table("Product")]
[Index(nameof(Code), IsUnique = true)]
public class Product : IEntity
{
    public enum ProductStatus
    {
        None,
        Warning
    }

    [Key]
    [Column(TypeName = "varchar(32)")]
    public string? Id { get; set; } = ModelsHelper.NewId();

    //品目コード
    [MaxLength(10)]
    public string? Code { get; set; }

    // 鋼種
    [MaxLength(100)]
    public string? Type { get; set; }
    // 仕上
    [MaxLength(100)]
    public string? Finish { get; set; }
    // 寸法１
    [MaxLength(100)]
    public string? Dimension1 { get; set; }
    // 寸法2
    [MaxLength(100)]
    public string? Dimension2 { get; set; }
    // 寸法3
    [MaxLength(100)]
    public string? Dimension3 { get; set; }
    // 寸法4
    [MaxLength(100)]
    public string? Dimension4 { get; set; }
    public ProductStatus? Status { get; set; }
}
