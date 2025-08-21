using Microsoft.OpenApi.Models;

namespace EP.API.Extensions;

public static class SwaggerExtension
{
    public static void AddSwaggerServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen(c =>
        {
            // تغییر اسم
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "EmpireOfPhone API 🚀", 
                Version = "v1",
                Description = "Its a api documentation for EmpireOfPhone API"
            });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Enter Your JWT Token Here For Example: Bearer {your token}"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}
                }
            });
        });


    }
}