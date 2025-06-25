using System.Data;
using System.Security.Cryptography;
using AutoMapper;
using Dapper;
using DotnetAPI.Data;
using DotnetAPI.Models;
using DotnetAPI.Dtos;
using DotnetAPI.Helpers;
using DotnetAPI.Repository.Interfaces;

namespace DotnetAPI.Repository
{
    public class FollowRepo : IFollowRepo
    {
        private readonly DataContextDapper _dapper;

        public FollowRepo(IConfiguration config)
        {
            _dapper = new DataContextDapper(config);
        }
        public bool FollowUser(int followerId, int followingId)
        {
            string sql = "EXEC TutorialAppSchema.spFollowUser @FollowerId = @FollowerIdParam, @FollowingId = @FollowingIdParam;";
            DynamicParameters sqlParameters = new DynamicParameters();
            sqlParameters.Add("FollowerIdParam", followerId, DbType.Int32);
            sqlParameters.Add("FollowingIdParam", followingId, DbType.Int32);

            return _dapper.ExecuteSqlWithParameters(sql, sqlParameters);
        }
        public bool UnfollowUser(int followerId, int followingId)
        {
            string sql = "EXEC TutorialAppSchema.spUnfollowUser @FollowerId = @FollowerIdParam, @FollowingId = @FollowingIdParam;";
            DynamicParameters sqlParameters = new DynamicParameters();
            sqlParameters.Add("FollowerIdParam", followerId, DbType.Int32);
            sqlParameters.Add("FollowingIdParam", followingId, DbType.Int32);

            return _dapper.ExecuteSqlWithParameters(sql, sqlParameters);
        }
        public List<FollowForGetMyFollowerDto> GetUserFollowers(int userId)
        {
            string sql = "EXEC TutorialAppSchema.spGetUserFollowers @UserId = @UserIdParam;";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("UserIdParam", userId);

            return _dapper.LoadDataWithParameters<FollowForGetMyFollowerDto>(sql, parameters).ToList();
        }
        public List<FollowForGetMyFollowingDto> GetUserFollowing(int userId)
        {
            string sql = "EXEC TutorialAppSchema.spGetUserFollowing @UserId = @UserIdParam;";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("UserIdParam", userId);

            return _dapper.LoadDataWithParameters<FollowForGetMyFollowingDto>(sql, parameters).ToList();
        }
    }
}