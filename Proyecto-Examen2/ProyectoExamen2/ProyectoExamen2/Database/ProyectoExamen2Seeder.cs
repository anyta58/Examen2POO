using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProyectoExamen2.Database.Entities;

namespace ProyectoExamen2.Database
{
    public class ProyectoExamen2Seeder
    {
        // si se necesita completarlo y anadirlo al program
        public static async Task LoadDataAsync(
            ProyectoExamen2Context context,
            ILoggerFactory loggerFactory
            )
        {
            try
            {
                await LoadClientsAsync(loggerFactory, context);
                await LoadLoansAsync(loggerFactory, context);
                await LoadAmortizationsAsync(loggerFactory, context);
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<ProyectoExamen2Seeder>();
                logger.LogError(e, "Error iniciando la data del API");
            }
        }


        public static async Task LoadClientsAsync(ILoggerFactory loggerFactory, ProyectoExamen2Context context)
        {
            try
            {
                var jsonFilePath = "SeedData/clients.json";
                var jsonContent = await File.ReadAllTextAsync(jsonFilePath);
                var clients = JsonConvert.DeserializeObject<List<ClientEntity>>(jsonContent);

                if (!await context.Clients.AnyAsync())
                {
                    context.AddRange(clients);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<ProyectoExamen2Seeder>();
                logger.LogError(e, "Error al ejecutar el seed de clientes");
            }
        }

        public static async Task LoadLoansAsync(ILoggerFactory loggerFactory, ProyectoExamen2Context context)
        {
            try
            {
                var jsonFilePath = "SeedData/loans.json";
                var jsonContent = await File.ReadAllTextAsync(jsonFilePath);
                var loans = JsonConvert.DeserializeObject<List<LoanEntity>>(jsonContent);

                if (!await context.Loans.AnyAsync())
                {
                    context.AddRange(loans);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<ProyectoExamen2Seeder>();
                logger.LogError(e, "Error al ejecutar el seed de prestamos");
            }
        }

        public static async Task LoadAmortizationsAsync(ILoggerFactory loggerFactory, ProyectoExamen2Context context)
        {
            try
            {
                var jsonFilePath = "SeedData/amortizations.json";
                var jsonContent = await File.ReadAllTextAsync(jsonFilePath);
                var amortizations = JsonConvert.DeserializeObject<List<AmortizationEntity>>(jsonContent);

                if (!await context.Amortizations.AnyAsync())
                {
                    context.AddRange(amortizations);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<ProyectoExamen2Seeder>();
                logger.LogError(e, "Error al ejecutar el seed de amortizaciones");
            }
        }

    }
}
