using EP.Application.Services;
using EP.Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EP.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {


        #region Services

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ILoggerService, LoggerService>();
        
        #endregion

        #region Mappers
        
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        
        #endregion
        
        return services;
    }
}