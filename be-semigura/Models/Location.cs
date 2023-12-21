using Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace be_semigura.Models;

[Table("Location")]
public class Location : AuditableEntityBase
{
    [Column(TypeName = "varchar(100)")]
    public string? Code { get; set; }

    [Column(TypeName = "varchar(100)")]
    public string? Name { get; set; }
    [Column(TypeName = "varchar(100)")]

    public string? FactoryId { get; set; }
    public Factory? Factory { get; set; }

    public List<LotContainer>? LotContainers { get; set; }
    public List<Container>? Containers { get; set; }

}
