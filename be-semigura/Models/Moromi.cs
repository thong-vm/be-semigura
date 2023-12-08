using Interfaces;
using Microsoft.EntityFrameworkCore;
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
    public string? Day { get; set; }
    public TimeSpan? Datetime { get; set; }
    [MaxLength(10)]
    public string? Bmd { get; set; }
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

}
