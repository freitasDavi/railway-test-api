using AzureTest.Utils;
using Microsoft.EntityFrameworkCore;

namespace AzureTest.Extensions;

public static class StartupDbExtensions
{
    public static async void CreateDbIfNotExists(this IHost host)
    {
        Console.WriteLine("Here?");
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;

        var context = services.GetRequiredService<Context>();

        await context.Database.MigrateAsync();
    }
}