using Microsoft.EntityFrameworkCore;
using ProyectoExamen2.Database;
using ProyectoExamen2.Helpers;

namespace ProyectoExamen2
{
    public class Startup
    {
        private IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // Configuracion Base de Datos
            services.AddDbContext<ProyectoExamen2Context>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Add custom service 
            //services.AddTransient<ICategoriesService, CategoriesSQLService>();
            //services.AddTransient<IAuthService, AuthService>();


            // Add other services if needed


            // Add AutoMapper
            services.AddAutoMapper(typeof(AutoMapperProfile));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
