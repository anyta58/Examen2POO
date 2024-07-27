using System.ComponentModel.DataAnnotations;

namespace ProyectoExamen2.Dtos.Clients
{
    public class ClientCreateDto
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El {0} del cliente es requerido.")]
        public string Name { get; set; }

        [Display(Name = "Numero de Identidad")]
        [RegularExpression("^[0-9]{13}$", ErrorMessage = "El {0} debe tener exactamente 13 dígitos.")]
        public int IdentityNumber { get; set; }
    }
}
