using EP.Domain.Interfaces.Services;
using EP.Shared.DTOs.PaginationDTOs;
using EP.Shared.DTOs.ResponseDTOs;
using EP.Shared.DTOs.UserDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace EP.API.Controllers.GeneralControllers;

public class UsersController(IUserService userService) : BaseController
{
    
    [HttpGet]
    [Authorize]
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

    [HttpPut("update")]
    public async Task<ActionResult> PutUpdateUser(
        [FromQuery] string userId,
        [FromBody] UserForUpdateDto user
        )
    {
        await userService.ReplaceUserAsync(userId, user);
        return Ok("User successfully Updated With Put Method !");
    }


    [HttpPatch("update")]
    public async Task<ActionResult> PatchUpdateUser(
        [FromQuery] string userId,
        [FromBody] JsonPatchDocument<UserForUpdateDto> userUpdate
    )
    {
        await userService.UpdateUserAsync(userId, userUpdate);
        return Ok("User successfully updated !");
    }
}