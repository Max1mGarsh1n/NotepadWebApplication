using Microsoft.EntityFrameworkCore;
using NotepadWebApp.DataAccess;
    
namespace NotepadWebApplication.IoC;

public class DbContextConfigurator
{
    public static void ConfigureServices(WebApplicationBuilder builder)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", false)
            .Build();
        var connectionString = configuration.GetValue<string>("NotepadDbContext");
        builder.Services.AddDbContextFactory<NotepadDbContext>(
            options => { options.UseNpgsql(connectionString); },
            ServiceLifetime.Scoped);
    }

    public static void ConfigureApplication(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<NotepadDbContext>>();
        using var context = contextFactory.CreateDbContext();
        context.Database.Migrate();
    }
}