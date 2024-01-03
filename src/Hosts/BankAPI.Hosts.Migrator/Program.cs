using BankAPI.Hosts.Migrator.DbContext;
using Microsoft.EntityFrameworkCore;

namespace BankAPI.Hosts.Migrator;

public class Program
{
    public static async Task Main(string[] args)
    {

        var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                services.AddServices(context.Configuration);
            })
            .Build();

        await MigrateDatabaseAsync(host.Services);
    }

    private static async Task MigrateDatabaseAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<MigratorDbContext>();
        await context.Database.MigrateAsync();
    }

}