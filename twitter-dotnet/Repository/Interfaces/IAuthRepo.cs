using DotnetAPI.Dtos;
using DotnetAPI.Models;

namespace DotnetAPI.Repository.Interfaces
{
    public interface IAuthRepo
    {
        bool Register(UserForRegistrationDto userForRegistration);
        bool ResetPassword(UserForLoginDto userForSetPassword);
        Dictionary<string, string> Login(UserForLoginDto userForLogin);
        string RefreshToken(int userIdParam);
    }
}