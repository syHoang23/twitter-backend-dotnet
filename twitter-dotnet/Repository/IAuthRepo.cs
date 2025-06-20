using DotnetAPI.Dtos;

namespace DotnetAPI.Repository.Interfaces
{
    public interface IAuthRepo
    {
        bool Register(UserForRegistrationDto userForRegistration);
        bool CreatePassword(UserForLoginDto userForSetPassword);
        bool ResetPassword(int userId, string password);
        Dictionary<string, string> Login(UserForLoginDto userForLogin);
        string RefreshToken(int userIdParam);
    }
}