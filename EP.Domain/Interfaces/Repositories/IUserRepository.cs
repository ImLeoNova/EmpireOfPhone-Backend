using EP.Domain.Entities;
using EP.Shared.DTOs.PaginationDTOs;
using Microsoft.AspNetCore.Identity;

namespace EP.Domain.Interfaces.Repositories;

public interface IUserRepository
{

    public Task<(IEnumerable<User> , int totalCounts )> GetAllUsersAsync(PaginationForGetDto paginationDto);
    public Task<User?> GetUserByUsernameAsync(string username);
    public Task<User?> GetUserByEmailAsync(string email);
    public Task<User?> GetUserByIdAsync(string id);
    public Task AddUserAsync(User user , string password);
    public Task UpdateUserAsync(User user);
    public Task DeleteUserAsync(User user);
}