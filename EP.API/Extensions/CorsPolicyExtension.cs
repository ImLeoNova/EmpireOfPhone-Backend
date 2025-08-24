namespace EP.API.Extensions;

public static class CorsPolicyExtension
{
    public static void AddCorsPolicies(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAnyOrigins", configurePolicy =>
            {
                configurePolicy
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
            
            options.AddPolicy("AllowForDevelopment", configurePolicy =>
            {
                configurePolicy
                    .WithOrigins("http://localhost:4200")
                    .AllowCredentials()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });
    }
}