
using EP.Domain.Interfaces.Services;
using EP.Shared.DTOs.UserDTOs;
using Microsoft.AspNetCore.Mvc;

namespace EP.API.Controllers.GeneralControllers;

public class AuthController( IAuthService authService ) : BaseController
{
    private void SetTokenCookie(string token)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = DateTime.UtcNow.AddDays(7), 
            Secure = true, 
            SameSite = SameSiteMode.Lax
        };
        Response.Cookies.Append("jwt-token", token, cookieOptions);
    }

    [HttpPost("login")]
    public async Task<ActionResult> LoginAsync([FromBody] UserForLogin user)
    {
        var token = await authService.LoginAsync(user);
        SetTokenCookie(token);
        return Ok("Token Successfully Sended");
    }
}   