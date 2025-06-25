using DotnetAPI.Dtos;
using DotnetAPI.Models;
using DotnetAPI.Repository;
using DotnetAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotnetAPI.Controllers
{
    [Authorize]
    public class FollowController : BaseApiController
    {
        private readonly IFollowRepo _followRepo;

        public FollowController(IFollowRepo followRepo)
        {
            _followRepo = followRepo;
        }
        [HttpGet("MyFollows")]
        public IEnumerable<FollowForGetMyFollowerDto> GetMyFollows()
        {
            var userIdStr = this.User.FindFirst("userId")?.Value;
            if (string.IsNullOrEmpty(userIdStr) || !int.TryParse(userIdStr, out int userId))
            {
                throw new UnauthorizedAccessException("Invalid or missing user ID.");
            }
            return _followRepo.GetUserFollowers(userId);
        }
        [HttpGet("MyFollowing")]
        public IEnumerable<FollowForGetMyFollowingDto> GetMyFollowing()
        {
            var userIdStr = this.User.FindFirst("userId")?.Value;
            if (string.IsNullOrEmpty(userIdStr) || !int.TryParse(userIdStr, out int userId))
            {
                throw new UnauthorizedAccessException("Invalid or missing user ID.");
            }
            return _followRepo.GetUserFollowing(userId);
        }
        [HttpPut("FollowUser/{followingId}")]
        public IActionResult FollowUser(int followingId)
        {
            var userIdStr = this.User.FindFirst("userId")?.Value;
            if (string.IsNullOrEmpty(userIdStr) || !int.TryParse(userIdStr, out int userId))
            {
                throw new UnauthorizedAccessException("Invalid or missing user ID.");
            }
            if (_followRepo.FollowUser(userId, followingId))
            {
                return Ok();
            }
            throw new Exception("Failed to follow user!!");
        }
        [HttpPut("UnFollowUser/{followingId}")]
        public IActionResult UnFollowUser(int followingId)
        {
            var userIdStr = this.User.FindFirst("userId")?.Value;
            if (string.IsNullOrEmpty(userIdStr) || !int.TryParse(userIdStr, out int userId))
            {
                throw new UnauthorizedAccessException("Invalid or missing user ID.");
            }
            if (_followRepo.UnfollowUser(userId, followingId))
            {
                return Ok();
            }
            throw new Exception("Failed to unfollow user!");
        }
    }
}