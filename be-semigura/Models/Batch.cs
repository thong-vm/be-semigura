using Interfaces;
using Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace be_semigura.Models;

[Table("Batch")]
public class Batch : IEntity
{


    [Key]
    [Column(TypeName = "varchar(32)")]
    public string? Id { get; set; } = ModelsHelper.NewId();
    [Column(TypeName = "varchar(32)")]
    public string? Name { get; set; }
    public DateTime? Time { get; set; }
    public List<Moromi> Moromis { get; set; } = new List<Moromi>();


}
