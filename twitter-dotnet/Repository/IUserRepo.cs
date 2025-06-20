using DotnetAPI.Dtos;
using DotnetAPI.Models;
namespace DotnetAPI.Repository.Interfaces
{
    public interface IUserRepo
    {
        IEnumerable<User> GetUsers(int userId = 0, bool isActive = false);
        IEnumerable<User> GetUserProfile(int userId);
        bool UpsertUser(User user);
        bool UpdatetUser(int userId, UserForUpdateDto userForUpdate);
        bool DeleteUser(int userId);
    }
}