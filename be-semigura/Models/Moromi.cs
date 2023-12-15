using Interfaces;
using Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace be_semigura.Models;

[Table("Moromi")]
public class Moromi : IEntity
{


    [Key]
    [Column(TypeName = "varchar(32)")]
    public string? Id { get; set; } = ModelsHelper.NewId();

    [Column(TypeName = "varchar(32)")]
    public string? DailyOrder { get; set; }
    public DateTime? Time { get; set; }
    [MaxLength(10)]
    public string? RoomTemperature { get; set; }
    [MaxLength(10)]
    public string? ProductTemperature { get; set; }
    [MaxLength(10)]
    public string? Baume { get; set; }
    [MaxLength(10)]
    public string? JapanSakeLevel { get; set; }
    [MaxLength(10)]
    public string? AlcoholContent { get; set; }
    [MaxLength(10)]
    public string? Acidity { get; set; }
    [MaxLength(10)]
    public string? AminoAcidContent { get; set; }
    [MaxLength(10)]
    public string? Glucose { get; set; }
    // Fogein key
    public string? BatchId { get; set; }
    public Batch? Batch { get; set; }

}
