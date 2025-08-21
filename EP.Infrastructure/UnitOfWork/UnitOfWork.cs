using EP.Domain.Interfaces.Repositories;
using EP.Domain.Interfaces.UnitOfWork;
using EP.Infrastructure.Data;

namespace EP.Infrastructure.UnitOfWork;

public class UnitOfWork(ExtraDbContext context, IUserRepository userRepository) : IUnitOfWork
{
    public IUserRepository Users { get; set; } = userRepository;

    public async Task<int> CompleteAsync()
    {
        return await context.SaveChangesAsync();
    }
}