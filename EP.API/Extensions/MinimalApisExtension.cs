namespace EP.API.Extensions;

public static class MinimalApisExtension
{
    public static void AddMinimalApis(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.MapGet("/", () => Results.Json(new
                {
                    Message = "Hello My Friend Im Arian Esmaeilzadeh And I Write This Message at 2025/8/23 6:51 And In This Time I am Sad or Normal And If you see this message your api is running and we don't have any error in our application and If you want to see the swagger documentation  you can go to this url https://localhost:8000/swagger And Thank you for read this message! Goodbye. "
                }));
        }
    }
}