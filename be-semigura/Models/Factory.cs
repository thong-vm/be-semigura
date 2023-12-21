using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Factory")]
    public class Factory : AuditableEntityBase
    {
        [Column(TypeName = "varchar(100)")]
        public string? Code { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string? Name { get; set; }

        [Column(TypeName = "varchar(15)")]
        public string? Phone { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string? Address { get; set; }

        [Column(TypeName = "varchar(5)")]
        public string? CountryCode { get; set; }


        public List<Lot>? Lots { get; set; }
        public List<be_semigura.Models.Location>? Locations { get; set; }
    }
}
