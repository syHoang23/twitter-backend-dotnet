using DotnetAPI.Models;
using DotnetAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DotnetAPI.Controllers
{
    public class TestController : BaseApiController
    {
        private readonly IPostRepo _postRepo;
        public TestController(IPostRepo postRepo)
        {
		    _postRepo = postRepo;
        }

        [HttpGet("Posts/{postId}/{userId}/{searchParam}")]
        public IEnumerable<Post> GetPosts(int postId = 0, int userId = 0, string searchParam = "None")
        {
            return _postRepo.GetPosts(postId, userId, searchParam);
        }

    }
}