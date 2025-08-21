using EP.Shared.DTOs.PaginationDTOs;
using EP.Shared.DTOs.ResponseDTOs;
using EP.Shared.DTOs.UserDTOs;

namespace EP.Domain.Interfaces.Services;

public interface IUserService
{
    public Task<ResponseForShowAllDto<UserForRead>> GetAllUsers(PaginationForGetDto paginationDto);

    public Task CreateUserAsync(UserForCreate user);

    public Task DeleteUserAsync(string userId);
}