using Microsoft.AspNetCore.Authorization;

namespace EP.API.Helpers;

public class HasAdminOrSelfUserAttribute : AuthorizeAttribute
{
    public HasAdminOrSelfUserAttribute()
    {
        Policy = "AdminOrSelf";
    }
}