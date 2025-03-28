using DotnetAPI.Models;
using DotnetAPI.Dtos;
namespace DotnetAPI.Repository.Interfaces
{
    public interface IUserRepo
    {
        IEnumerable<User> GetUsers(int userId, bool isActive);
        IEnumerable<User> GetUserProfile(int userId);
        bool UpsertUser(User user);
        bool DeleteUser(int userId);

    }
}