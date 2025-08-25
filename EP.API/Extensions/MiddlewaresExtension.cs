using EP.API.Middlewares;

namespace EP.API.Extensions;

public static class MiddlewaresExtension
{
    public static void AddAspMiddlewares(this WebApplication app)
    {
        app.UseCors("AllowAnyOrigins");

        app.UseMiddleware<ExceptionHandlingMiddleware>();

        app.UseHttpsRedirection();
        
        if (app.Environment.IsDevelopment()) app.UseSwaggerMiddlewares();

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();
    }

}