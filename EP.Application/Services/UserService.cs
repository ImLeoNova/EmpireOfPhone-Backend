 using AutoMapper;
 using EP.Application.Exceptions;
 using EP.Domain.Entities;
using EP.Domain.Interfaces.Repositories;
using EP.Domain.Interfaces.Services;
using EP.Shared.DTOs.PaginationDTOs;
using EP.Shared.DTOs.ResponseDTOs;
using EP.Shared.DTOs.UserDTOs;

namespace EP.Application.Services;

public class UserService(
    IUserRepository userRepository,
    IMapper mapper
    ) : IUserService
{
    public async Task<ResponseForShowAllDto<UserForRead>> GetAllUsers(PaginationForGetDto paginationDto)
    {
        IEnumerable<User> users = await userRepository.GetAllUsersAsync(paginationDto);
        IEnumerable<UserForRead> usersForShow = mapper.Map<IEnumerable<UserForRead>>(users);
        ResponseForShowAllDto<UserForRead> response = new ResponseForShowAllDto<UserForRead>()
        {
            Data = usersForShow,
            Meta = new MetaDataDto()
            {
                PageId = paginationDto.PageId,
                PageSize = paginationDto.PageSize
            }
        };
        
        return response;
    }
    public async Task CreateUserAsync(UserForCreate user)
    {
        User userEntity = mapper.Map<User>(user);
        if (await userRepository.GetUserByUsernameAsync(user.UserName) != null) throw new InvalidOperationException( $"User With Name {userEntity.UserName} Exists!");
        if (await userRepository.GetUserByEmailAsync(user.Email) != null) throw new InvalidOperationException( $"User With Email {user.Email} Exists!"); 
        await userRepository.AddUserAsync(userEntity);
    }
    public async Task DeleteUserAsync(string userId)
    { 
        User? userEntity = await userRepository.GetUserByIdAsync(userId);
        if (userEntity == null)
        {
            throw new NotfoundException($"User with id {userId} NotFound !");
        }else
        {
            await userRepository.DeleteUserAsync(userEntity);
        }
    } 
    
}