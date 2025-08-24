using Microsoft.OpenApi.Models;

namespace EP.API.Extensions;

public static class SwaggerExtension
{
    public static void AddSwaggerServices(this IServiceCollection services)
    {
        
        services.AddOpenApi();
        services.AddSwaggerGen(c =>
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
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Enter your JWT token in the text input below.\nExample: Bearer {your token}"
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

    public static void UseSwaggerMiddlewares(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "EmpireOfPhone API v1");
                c.DocumentTitle = "EmpireOfPhone API Docs";
            });
        }
    }
}