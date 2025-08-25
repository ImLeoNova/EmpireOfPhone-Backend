using EP.Domain.Entities;

namespace EP.Domain.Interfaces.Services;

public interface IJwtService
{
    public Task<string> GenerateToken(User user);
}