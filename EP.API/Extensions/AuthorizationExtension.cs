using System.Security.Claims;

namespace EP.API.Extensions;

public static class AuthorizationExtension
{
    public static IServiceCollection AddAuthorizationPolicies(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy(name: "AdminOrSelf", configurePolicy: policy =>
            {
                policy.RequireAssertion(context =>
                {
                    var userIdClaim = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                    var routeId = context.Resource as HttpContext ?? throw new Exception("HttpContext not available");

                    var idInRoute = routeId.Request.RouteValues["id"]?.ToString();

                    return context.User.IsInRole("Administrator") || userIdClaim == idInRoute;
                });
            });
        });

        return services;
    }
}