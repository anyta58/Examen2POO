using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoExamen2.Database.Entities
{

    [Table("clients", Schema = "dbo")]
    public class ClientEntity : BaseEntity
    {
        [StringLength(50)]
        [Column("name")]
        public string Name { get; set; }

        [RegularExpression("^[0-9]{13}$")]
        [Column("identity_number")]
        public int IdentityNumber { get; set; }
    }
}
