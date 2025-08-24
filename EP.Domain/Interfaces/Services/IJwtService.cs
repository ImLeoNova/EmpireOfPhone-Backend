using EP.Domain.Entities;

namespace EP.Domain.Interfaces.Services;

public interface IJwtService
{
    public string GenerateToken(User user);
}