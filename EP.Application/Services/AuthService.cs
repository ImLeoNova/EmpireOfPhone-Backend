using EP.Domain.Entities;
using EP.Domain.Interfaces.Services;
using EP.Shared.DTOs.UserDTOs;
using Microsoft.AspNetCore.Identity;

namespace EP.Application.Services;

public class AuthService( 
    UserManager<User> userManager,
    IJwtService jwtService
    ) : IAuthService
{
    public async Task<string> LoginAsync(UserForLogin user)
    {

        var userEntity = await userManager.FindByNameAsync(user.Username!);
        if ((userEntity == null || !await userManager.CheckPasswordAsync(userEntity, user.Password!)))
        {
            throw new InvalidOperationException("Invalid Credentials");
        }

        var token = await jwtService.GenerateToken(userEntity);
        return token;

    }
}