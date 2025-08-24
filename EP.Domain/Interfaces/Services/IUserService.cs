using EP.Shared.DTOs.PaginationDTOs;
using EP.Shared.DTOs.ResponseDTOs;
using EP.Shared.DTOs.UserDTOs;
using Microsoft.AspNetCore.JsonPatch;

namespace EP.Domain.Interfaces.Services;

public interface IUserService
{
    public Task<ResponseForShowAllDto<UserForRead>> GetAllUsers(PaginationForGetDto paginationDto);
    public Task CreateUserAsync(UserForCreate user);
    public Task DeleteUserAsync(string userId);
    public Task ReplaceUserAsync(string userId, UserForUpdateDto user);
    public Task UpdateUserAsync(string userId, JsonPatchDocument<UserForUpdateDto> userUpdate);
    
}