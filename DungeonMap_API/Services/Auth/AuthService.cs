using DungeonMap_API.Models.Auth;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMap_API.Services.Auth
{
    public class AuthService : IAuthService
    {
        private IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public byte[] GenerateSalt()
        {
            // generate a 128-bit salt using a secure PRNG
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return salt;
        }

        public string GenerateHash(string plainTextPassword, byte[] passwordSalt)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: plainTextPassword,
                salt: passwordSalt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
        }

        public bool VerifyPassword(string passwordHash, string passwordSalt, string plainTextPassword)
        {
            var salt = Encoding.UTF8.GetBytes(passwordSalt);

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = GenerateHash(plainTextPassword, salt);

            return hashed == passwordHash;
        }

        public string GenerateToken(TokenRequest request)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, request.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Uri"],
                audience: _configuration["Uri"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(90),
                signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
