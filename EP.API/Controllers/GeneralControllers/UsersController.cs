using EP.Domain.Interfaces.Services;
using EP.Shared.DTOs;
using EP.Shared.DTOs.PaginationDTOs;
using EP.Shared.DTOs.ResponseDTOs;
using EP.Shared.DTOs.UserDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EP.API.Controllers.GeneralControllers;

public class UsersController(IUserService userService) : BaseController
{
    
    [AllowAnonymous]
    [HttpGet]
    public async Task<ResponseForShowAllDto<UserForRead>> GetAllUsers([FromQuery] PaginationForGetDto paginationDto)
    { 
        return await userService.GetAllUsers(paginationDto);
    }

    [HttpPost("add")]
    public async Task<ActionResult> CreateUser([FromBody] UserForCreate user)
    {
        if (ModelState.IsValid == false) return BadRequest(ModelState);
        await userService.CreateUserAsync(user);
        return Ok("User Successfully Created !");
    }

    [HttpDelete("delete")]
    public async Task<ActionResult> DeleteUser([FromQuery] string id)
    {
        if (ModelState.IsValid == false) return BadRequest(ModelState);
        await userService.DeleteUserAsync(id);
        return Ok("User Successfully Deleted !");
    }
}