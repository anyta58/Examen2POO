using Microsoft.EntityFrameworkCore;
using ProyectoExamen2.Database.Entities;

namespace ProyectoExamen2.Database
{
    public class ProyectoExamen2Context : DbContext
    {
        public ProyectoExamen2Context(DbContextOptions options
            // authser
            ) : base(options) 
        {
            //agregar authservice
        }

        //Aqui irian las tablas
        public DbSet<ClientEntity> Clients { get; set; }
        public DbSet<LoanEntity> Loans { get; set; }
        public DbSet<AmortizationEntity> Amortizations { get; set; }

    }
}
