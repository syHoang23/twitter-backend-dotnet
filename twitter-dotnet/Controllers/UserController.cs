using DotnetAPI.Repository;
using DotnetAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DotnetAPI.Repository.Interfaces;

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
    public IEnumerable<User> GetUsers(int userId, bool isActive)
    {
        return _userRepo.GetUsers(userId, isActive);

        throw new Exception("Failed to Get Users");
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
    [HttpPut("UpsertUser")]
    public IActionResult UpsertUser(User user)
    {   
        if (_userRepo.UpsertUser(user))
        {
            return Ok();
        }

        throw new Exception("Failed to Update User");
    }
    [HttpDelete("DeleteUser/{userId}")]
    public IActionResult DeleteUser(int userId)
    {
        if (_userRepo.DeleteUser(userId))
        {
            return Ok();
        } 

        throw new Exception("Failed to Delete User");
    }
}
