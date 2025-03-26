using System.Data;
using Dapper;
using DotnetAPI.Data;
using DotnetAPI.Dtos;
using DotnetAPI.Repository;
using DotnetAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotnetAPI.Controllers;

[Authorize]
public class UserController : BaseApiController
{
    private readonly DataContextDapper _dapper;
    private readonly UserRepo _userRepo;
    public UserController(IConfiguration config)
    {
        _dapper = new DataContextDapper(config);
        _userRepo = new UserRepo(config);
    }
    [AllowAnonymous]
    [HttpGet("TestConnection")]
    public DateTime TestConnection()
    {
        return _dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");
    }

    [HttpGet("GetUsers/{userId}/{isActive}")]
    public IEnumerable<User> GetUsers(int userId, bool isActive)
    {
        return _userRepo.GetUsers(userId, isActive);
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
        string sql = @"TutorialAppSchema.spUser_Delete
            @UserId = @UserIdParameter";

        DynamicParameters sqlParameters = new DynamicParameters();
        sqlParameters.Add("@UserIdParameter", userId, DbType.Int32);

        if (_dapper.ExecuteSqlWithParameters(sql, sqlParameters))
        {
            return Ok();
        } 

        throw new Exception("Failed to Delete User");
    }
}
