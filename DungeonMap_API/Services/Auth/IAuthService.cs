using DungeonMap_API.Models.Auth;

namespace DungeonMap_API.Services.Auth
{
    public interface IAuthService
    {
        string GenerateHash(string plainTextPassword, byte[] passwordSalt);
        byte[] GenerateSalt();
        bool VerifyPassword(string passwordHash, string passwordSalt, string plainTextPassword);
        string GenerateToken(TokenRequest request);
    }
}