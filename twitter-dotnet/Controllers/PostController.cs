using DotnetAPI.Dtos;
using DotnetAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DotnetAPI.Repository;

namespace DotnetAPI.Controllers
{
    [Authorize]
    public class PostController : BaseApiController
    {
        private readonly PostRepo _postRepo;
        public PostController(IConfiguration config)
        {
            _postRepo = new PostRepo(config);
        }

        [HttpGet("Posts/{postId}/{userId}/{searchParam}")]
        public IEnumerable<Post> GetPosts(int postId = 0, int userId = 0, string searchParam = "None")
        {
            return _postRepo.GetPosts(postId, userId, searchParam);
        }

        [HttpGet("MyPosts")]
        public IEnumerable<Post> GetMyPosts()
        {
            var userIdStr = this.User.FindFirst("userId")?.Value;
            if (string.IsNullOrEmpty(userIdStr) || !int.TryParse(userIdStr, out int userId))
            {
                throw new UnauthorizedAccessException("Invalid or missing user ID.");
            }
            return _postRepo.GetMyPosts(userId);
        }

        [HttpPut("UpsertPost")]
        public IActionResult UpsertPost(PostForUpsertDto postToUpsert)
        {
            var userIdStr = this.User.FindFirst("userId")?.Value;
            if (string.IsNullOrEmpty(userIdStr) || !int.TryParse(userIdStr, out int userId))
            {
                throw new UnauthorizedAccessException("Invalid or missing user ID.");
            }
            if (_postRepo.UpsertPost(postToUpsert, userId))
            {
                return Ok();
            }
            throw new Exception("Fail to upsert post!");
        }


        [HttpDelete("Post/{postId}")]
        public IActionResult DeletePost(int postId)
        {
            var userIdStr = this.User.FindFirst("userId")?.Value;
            if (string.IsNullOrEmpty(userIdStr) || !int.TryParse(userIdStr, out int userId))
            {
                return Unauthorized("Không tìm thấy userId hoặc userId không hợp lệ.");
            }
            if (_postRepo.DeletePost(postId, userId))
            {
                return Ok();
            }
            throw new Exception("Failed to delete post!");
        }
    }
}