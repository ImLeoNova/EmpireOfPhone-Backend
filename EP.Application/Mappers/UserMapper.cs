using AutoMapper;
using EP.Domain.Entities;
using EP.Shared.DTOs;
using EP.Shared.DTOs.UserDTOs;

namespace EP.Application.Mappers;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<User, UserForRead>();
        
        CreateMap<UserForCreate, User>();
        
        CreateMap<UserForUpdateDto, User>();
    }
}