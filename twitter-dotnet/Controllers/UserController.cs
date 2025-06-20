using DotnetAPI.Repository;
using DotnetAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DotnetAPI.Repository.Interfaces;
using DotnetAPI.Dtos;

namespace DotnetAPI.Controllers;

[Authorize]
public class UserController : BaseApiController
{
    private readonly IUserRepo _userRepo;
    public UserController(IUserRepo userRepo)
    {
        _userRepo = userRepo;
    }
    [HttpGet("GetUsers/{userId}/{isActive}")]
    public IEnumerable<User> GetUsers(int userId = 0, bool isActive = false)
    {
        var users = _userRepo.GetUsers(userId, isActive);
        if (users == null)
        {
            throw new Exception("Failed to Get Users");
        }
        return users;
    }
    [HttpPut("MyProfile")]
    public IEnumerable<User> GetUserProfile()
    {
        var userIdStr = this.User.FindFirst("userId")?.Value;
        if (string.IsNullOrEmpty(userIdStr) || !int.TryParse(userIdStr, out int userId))
        {
            throw new UnauthorizedAccessException("Invalid or missing user ID.");
        }
        return _userRepo.GetUserProfile(userId);
    }
    [HttpPut("UpdateUser")]
    public IActionResult UpdateUser(UserForUpdateDto userForUpdate)
    {   
        var userIdStr = this.User.FindFirst("userId")?.Value;
        if (string.IsNullOrEmpty(userIdStr) || !int.TryParse(userIdStr, out int userId))
        {
            throw new UnauthorizedAccessException("Invalid or missing user ID.");
        }
        if (_userRepo.UpdatetUser(userId, userForUpdate))
        {
            return Ok();
        }

        throw new Exception("Failed to Update User");
    }
    [HttpDelete("DeleteUser")]
    public IActionResult DeleteUser()
    {
        var userIdStr = this.User.FindFirst("userId")?.Value;
        if (string.IsNullOrEmpty(userIdStr) || !int.TryParse(userIdStr, out int userId))
        {
            throw new UnauthorizedAccessException("Invalid or missing user ID.");
        }
        if (_userRepo.DeleteUser(userId))
        {
            return Ok();
        } 

        throw new Exception("Failed to Delete User");
    }
}
