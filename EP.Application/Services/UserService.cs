 using AutoMapper;
 using EP.Application.Exceptions;
 using EP.Domain.Entities;
using EP.Domain.Interfaces.Repositories;
using EP.Domain.Interfaces.Services;
using EP.Shared.DTOs.PaginationDTOs;
using EP.Shared.DTOs.ResponseDTOs;
using EP.Shared.DTOs.UserDTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;

namespace EP.Application.Services;

public class UserService(
    IUserRepository userRepository,
    IMapper mapper,
    UserManager<User> userManager) : IUserService
{

    #region GetAllUsersAsync
    
    /// <summary>
    ///     َA Function for get All User With Pagination
    /// </summary>
    /// <param name="paginationDto"></param>
    /// <returns></returns>
    public async Task<ResponseForShowAllDto<UserForRead>> GetAllUsers(PaginationForGetDto paginationDto)
    {
        
        // Get All Users From UserRepository
        var (users , totalCounts) = await userRepository.GetAllUsersAsync(paginationDto);
        
        // Map Users To UserForRead
        IEnumerable<UserForRead> usersForShow = mapper.Map<IEnumerable<UserForRead>>(users);
        
        // Show Response with data and metadata to user
        
        ResponseForShowAllDto<UserForRead> response = new ResponseForShowAllDto<UserForRead>()
        {
            Data = usersForShow,
            
            // Show Meta Data Dto
            Meta = new MetaDataDto()
            {
                PageId = paginationDto.PageId,
                PageSize = paginationDto.PageSize,
                TotalCount = totalCounts,
                TotalPages = (int) Math.Ceiling( (double) totalCounts / paginationDto.PageSize )
            }
        };
        
        return response;
    }

    public async Task<UserForRead> GetUserByIdAsync(string id)
    {
        var user = await userRepository.GetUserByIdAsync(id);

        if (user == null)
        {
            throw new NotfoundException($"User with id {id} Notfound !");
        }
        var mappedUser = mapper.Map<UserForRead>(user);
        return mappedUser;
    }

    #endregion
    
    #region CreateUserAsync

    /// <summary>
    ///  Create A User In Microsoft User Identity
    /// </summary>
    /// <param name="user"></param>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task CreateUserAsync(UserForCreate user)
    {
        User userEntity = mapper.Map<User>(user);
        if (await userRepository.GetUserByUsernameAsync(user.UserName) != null) throw new InvalidOperationException( $"User With Name {userEntity.UserName} Exists!");
        if (await userRepository.GetUserByEmailAsync(user.Email) != null) throw new InvalidOperationException( $"User With Email {user.Email} Exists!"); 
        await userRepository.AddUserAsync(userEntity , user.Password);
        // await userManager.AddToRoleAsync(userEntity, "Member");
    }    

    #endregion

    #region DeleteUserAsync

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

    #endregion

    #region ReplaceUserAsync

    public async Task ReplaceUserAsync(string userId, UserForUpdateDto user)
    {
        User? userEntity = await userRepository.GetUserByIdAsync(userId);

        if (userEntity == null) throw new NotfoundException(
            $"User with id {userId} Notfound !"
        );
        // User userForUpdate = mapper.Map<User>(user);
        
        mapper.Map(user, userEntity);
        
        await userRepository.UpdateUserAsync(userEntity);
    }

    #endregion
    
    #region UpdateUserAsync

    public async Task UpdateUserAsync(string userId, JsonPatchDocument<UserForUpdateDto> user)
    {
        var userEntity = await userRepository.GetUserByIdAsync(userId);
        
        if (userEntity == null) 
            throw new NotfoundException($"User with id {userId} Not Found !");
        
        // Map User To UserForUpdateDto
        var userForUpdate = mapper.Map<UserForUpdateDto>(userEntity);
        
        user.ApplyTo(userForUpdate);
        
        var userForUpdateEntity = mapper.Map<User>(userForUpdate);
        
        await userRepository.UpdateUserAsync(userForUpdateEntity);
    }

    #endregion
}