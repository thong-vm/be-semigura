using Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class AuditableEntityBase : IEntity
    {
        [Key]
        [Column(TypeName = "varchar(100)")]
        public string? Id { get; set; } = ModelsHelper.NewId();
        public DateTime? CreatedOn { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string? CreatedById { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string? ModifiedById { get; set; }
    }
}
