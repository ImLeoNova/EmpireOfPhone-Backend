using EP.Domain.Entities;
using EP.Domain.Interfaces.Repositories;
using EP.Infrastructure.Data;
using EP.Shared.DTOs.PaginationDTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EP.Infrastructure.Repositories;

public class UserRepository(
    ExtraDbContext context,
    UserManager<User> userManager) : IUserRepository
{
    public async Task<IEnumerable<User>> GetAllUsersAsync(PaginationForGetDto paginationDto)
    {
        IQueryable<User> users = context.Users.OrderBy(
            c=>c.Id
            )
            .Skip(paginationDto.PageSize * (paginationDto.PageId - 1))
            .Take(paginationDto.PageSize);
        return await users.ToListAsync();
    }
    
    public async Task<User?> GetUserByIdAsync(string id)
    {
        return await userManager.FindByIdAsync(id);
    }

    public async Task AddUserAsync(User user)
    {
        await userManager.CreateAsync(user);
    }

    public async Task<User?> GetUserByUsernameAsync(string username)
    {
        return await userManager.FindByNameAsync(username);
    }
    
    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await userManager.FindByEmailAsync(email);
    }

    public Task UpdateUserAsync(User user)
    {
        context.Users.Update(user);
        return Task.CompletedTask;
    }

    public async Task<IdentityResult> DeleteUserAsync(User user)
    {
        return await userManager.DeleteAsync(user);
    }
}