using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace EP.API.Extensions;

public static class JwtConfigurationExtension
{
    public static void AddJwtConfiguration(this IServiceCollection services, IConfiguration config)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateAudience = true,
                RoleClaimType = ClaimTypes.Role,
                ValidateIssuer = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = config["JWT_SETTINGS:Issuer"],
                ValidAudience = config["JWT_SETTINGS:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(config["JWT_SETTINGS:Secret"]!))
            };

            options.Events = new JwtBearerEvents
            {
                OnMessageReceived = context =>
                {
                    if (context.Request.Cookies.ContainsKey("jwt-token"))
                    {
                        context.Token = context.Request.Cookies["jwt-token"];
                    }
                    return Task.CompletedTask;
                }
            };
        });
    }
}