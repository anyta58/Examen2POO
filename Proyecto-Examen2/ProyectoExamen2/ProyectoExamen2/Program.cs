using ProyectoExamen2;
using ProyectoExamen2.Database;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);

var app = builder.Build();

startup.Configure(app, app.Environment);

//Agregar seeder
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();

    try
    {
        var Context = services.GetRequiredService<ProyectoExamen2Context>();
        await ProyectoExamen2Seeder.LoadDataAsync(Context, loggerFactory);
    }
    catch (Exception e)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(e, "Error al ejecutar el seed de datos");
    }
}

app.Run();