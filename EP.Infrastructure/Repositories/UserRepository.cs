using EP.Domain.Entities;
using EP.Domain.Interfaces.Repositories;
using EP.Infrastructure.Data;
using EP.Shared.DTOs.PaginationDTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EP.Infrastructure.Repositories;

public class UserRepository(
    ExtraDbContext context,
    UserManager<User> userManager
    ) : IUserRepository
{
    public async Task<(IEnumerable<User>, int totalCounts )> GetAllUsersAsync(PaginationForGetDto paginationDto)
    {

        var totalCounts = context.Users.Count(); 
        
        IQueryable<User> users = context.Users.OrderBy(
            c=>c.Id
            )
            .Skip(paginationDto.PageSize * (paginationDto.PageId - 1))
            .Take(paginationDto.PageSize);
        return (
            await users.ToListAsync(), 
            totalCounts
            );
    }
    
    public async Task<User?> GetUserByIdAsync(string id)
    {
        return await userManager.FindByIdAsync(id);
    }

    public async Task AddUserAsync(User user, string password)
    {
        await userManager.CreateAsync(user, password:password);
        await context.SaveChangesAsync();
    }

    public async Task<User?> GetUserByUsernameAsync(string username)
    {
        return await userManager.FindByNameAsync(username);
    }
    
    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await userManager.FindByEmailAsync(email);
    }

    public async Task UpdateUserAsync(User user)
    {
        await userManager.UpdateAsync(user);
        await context.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(User user)
    {
        await userManager.DeleteAsync(user);
        await context.SaveChangesAsync();
    }
}