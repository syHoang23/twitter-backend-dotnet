using DotnetAPI.Data;
using DotnetAPI.Dtos;

namespace DotnetAPI.Helpers.Interfaces
{
    public interface IAuthHelper
    {
        byte[] GetPasswordHash(string password, byte[] passwordSalt);
        string CreateToken(int userId);
        public bool CheckUserExists(string email);
    }
}