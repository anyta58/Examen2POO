using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoExamen2.Database.Entities
{
    public class BaseEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
    }
}
