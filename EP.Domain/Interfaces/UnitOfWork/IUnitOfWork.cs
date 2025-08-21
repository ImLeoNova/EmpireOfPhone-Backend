using EP.Domain.Interfaces.Repositories;

namespace EP.Domain.Interfaces.UnitOfWork;

public interface IUnitOfWork
{
    IUserRepository Users { get; set; }

    Task<int> CompleteAsync();
}