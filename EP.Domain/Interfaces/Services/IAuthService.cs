using EP.Shared.DTOs.UserDTOs;

namespace EP.Domain.Interfaces.Services;

public interface IAuthService
{
    public Task<string> LoginAsync(UserForLogin user);
}