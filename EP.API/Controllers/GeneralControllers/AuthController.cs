
using EP.Domain.Interfaces.Services;
using EP.Infrastructure.Authentication;
using EP.Shared.DTOs.UserDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EP.API.Controllers.GeneralControllers;

public class AuthController( IAuthService authService ,  
    IOptions<JwtSettings> settings) : BaseController
{

    private readonly JwtSettings _jwtSettings = settings.Value;
    
    private void SetTokenCookie(string token)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.EXPRIYMINUTES), 
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