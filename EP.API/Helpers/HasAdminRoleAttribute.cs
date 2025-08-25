using Microsoft.AspNetCore.Authorization;

namespace EP.API.Helpers;

public class HasAdminRoleAttribute : AuthorizeAttribute
{
    public HasAdminRoleAttribute()
    {
        Roles = "Administrator";
    }
}