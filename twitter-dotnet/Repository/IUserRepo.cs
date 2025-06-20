using DotnetAPI.Models;
namespace DotnetAPI.Repository.Interfaces
{
    public interface IUserRepo
    {
        IEnumerable<User> GetUsers(int userId = 0, bool isActive = false);
        IEnumerable<User> GetUserProfile(int userId);
        bool UpsertUser(User user);
        bool DeleteUser(int userId);
    }
}