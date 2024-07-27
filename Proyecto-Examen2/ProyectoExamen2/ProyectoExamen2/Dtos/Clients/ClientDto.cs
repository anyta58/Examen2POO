using System.ComponentModel.DataAnnotations;

namespace ProyectoExamen2.Dtos.Clients
{
    public class ClientDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int IdentityNumber { get; set; }
    }
}
