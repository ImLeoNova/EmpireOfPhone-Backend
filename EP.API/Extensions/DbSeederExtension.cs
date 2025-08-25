using EP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EP.API.Extensions;

public static class DbSeederExtension
{
    public static async void UseDbSeederExtension(this WebApplication app)
    {
        
        await using var scope = app.Services.CreateAsyncScope();
        
        var dbContexts = new (string name , DbContext dbContext)[]
        {
            ( "ExtraDataContext", scope.ServiceProvider.GetRequiredService<AppIdentityContext>())
        };
        foreach (var context in dbContexts)
        {
            var pendingMigrations = await context.dbContext.Database.GetPendingMigrationsAsync();
            if (pendingMigrations.Any())
            {
                throw new Exception("❌ Database is not up to date. Run `dotnet ef database update`.");
            }

            // Check if we even have migrations at all
            var allMigrations = context.dbContext.Database.GetMigrations();
            if (!allMigrations.Any())
            {
                throw new Exception("❌ No migrations found. Run `dotnet ef migrations add InitialCreate`.");
            }
        }
        
        
        var serviceProviders = scope.ServiceProvider;
        await DbSeeder.SeedAsync(serviceProviders);
    }
}