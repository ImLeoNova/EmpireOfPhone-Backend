using EP.Domain.Entities;
using EP.Domain.Interfaces.Repositories;
using EP.Domain.Interfaces.Services;
using EP.Domain.Interfaces.UnitOfWork;
using EP.Infrastructure.Authentication;
using EP.Infrastructure.Data;
using EP.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EP.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration config
        )
    {
        
        #region DbContexts
        
        services.AddDbContext<AppIdentityContext>(options =>
        {
            options.UseSqlite(config.GetConnectionString("ExtraDataConnection"));
        });
        
        #endregion
        
        #region Identity
        
        services.AddIdentityCore<User>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<AppIdentityContext>();
        #endregion
        
        #region Repositories
        
        services.AddScoped<IUserRepository, UserRepository>();
        
        
        
        #endregion
        
        #region Authentication

        services.AddScoped<IJwtService, JwtService>();
        
        #endregion
        
        return services;
    }
}