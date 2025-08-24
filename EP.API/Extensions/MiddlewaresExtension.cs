using EP.API.Middlewares;

namespace EP.API.Extensions;

public static class MiddlewaresExtension
{
    public static void AddAspMiddlewares(this WebApplication app)
    {
        app.UseCors("AllowAnyOrigins");

        app.UseHttpsRedirection();

        app.UseSwaggerMiddlewares();

        app.UseAuthentication();
        
        app.UseAuthorization();

        app.MapControllers();

        app.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}