using DotnetAPI.Dtos;
using DotnetAPI.Models;

namespace DotnetAPI.Repository.Interfaces
{
    public interface IPostRepo
    {
        IEnumerable<Post> GetPosts(int postId = 0, int userId = 0, string searchParam = "None");
        IEnumerable<Post> GetMyPosts(int userId);
        bool UpsertPost(PostForUpsertDto postToUpsert,int userId);
        bool DeletePost(int postId, int userId);
    }
}