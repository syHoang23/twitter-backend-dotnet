using DotnetAPI.Dtos;
using DotnetAPI.Models;

namespace DotnetAPI.Repository.Interfaces
{
    public interface IFollowRepo
    {
        bool FollowUser(int followerId, int followingId);
        bool UnfollowUser(int followerId, int followingId);
        List<FollowForGetMyFollowerDto> GetUserFollowers(int userId);
        List<FollowForGetMyFollowingDto> GetUserFollowing(int userId);
    }
}