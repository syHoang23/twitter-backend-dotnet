using DotnetAPI.Dtos;
using DotnetAPI.Repository;
using DotnetAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotnetAPI.Controllers
{
    [Authorize]
    public class AuthController : BaseApiController
    {
        private readonly IAuthRepo _authRepo;
        public AuthController(IAuthRepo authRepo)
        {
            _authRepo = authRepo;
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public IActionResult Register(UserForRegistrationDto userForRegistration)
        {
            if(_authRepo.Register(userForRegistration))
            {
                return Ok();
            }
            throw new Exception("Passwords do not match!");
        }

        [HttpPut("ResetPassword")]
        public IActionResult ResetPassword(UserForLoginDto userForSetPassword)
        {
            if (_authRepo.ResetPassword(userForSetPassword))
            {
                return Ok();
            }
            throw new Exception("Failed to update password!");
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login(UserForLoginDto userForLogin)
        {
            return Ok(_authRepo.Login(userForLogin));
            throw new Exception("Failed to login!");
        }

        [HttpGet("RefreshToken")]
        public string RefreshToken()
        {
            var userIdStr = this.User.FindFirst("userId")?.Value;
            if (string.IsNullOrEmpty(userIdStr) || !int.TryParse(userIdStr, out int userId))
            {
                throw new UnauthorizedAccessException("Invalid or missing user ID.");
            }
            return _authRepo.RefreshToken(userId);
            throw new Exception("Failed to reset password!");
        }
    }
}