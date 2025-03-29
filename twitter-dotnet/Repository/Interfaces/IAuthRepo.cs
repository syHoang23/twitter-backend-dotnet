using DotnetAPI.Dtos;

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