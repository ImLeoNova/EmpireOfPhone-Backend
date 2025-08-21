using EP.Application.Exceptions;

namespace EP.API.Middlewares;

public class ExceptionHandlingMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        
        catch (InvalidOperationException ex)
        {
            context.Response.StatusCode = 400; // BadRequest
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(new { error = ex.Message });
        }
        
        catch (NotfoundException ex)
        {
            context.Response.StatusCode = 404; // NotFound Exception
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(new { error = ex.Message }); 
        }
        
        catch (Exception)
        {
            context.Response.StatusCode = 500; // Internal Server Err
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(new { error = $"Something went wrong at server " });
        }

    }
}
