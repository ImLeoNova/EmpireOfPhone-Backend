using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EP.Domain.Entities;
using EP.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace EP.Infrastructure.Authentication;

public class JwtService(
    IOptions<JwtSettings> settings,
    UserManager<User> userManager 
    ) : IJwtService
{
    private readonly JwtSettings _settings = settings.Value;


    public async Task<string> GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_settings.Secret);

        var roles = await userManager.GetRolesAsync(user);

        var claims = new List<Claim>
        {
            new (ClaimTypes.NameIdentifier , user.Id),
            new (ClaimTypes.Name, user.UserName ?? "Not Set"),
        };

        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(_settings.EXPRIYMINUTES),
            Issuer = _settings.Issuer,
            Audience = _settings.Audience,
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256
            )
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

}