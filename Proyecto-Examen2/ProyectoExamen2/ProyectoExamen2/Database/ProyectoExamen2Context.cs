using Microsoft.EntityFrameworkCore;

namespace ProyectoExamen2.Database
{
    public class ProyectoExamen2Context : DbContext
    {
        public ProyectoExamen2Context(DbContextOptions options
            // authser
            ) : base(options) 
        {
            // Probable agregar authservice
        }
        
    }

    //Aqui irian las tablas
}
