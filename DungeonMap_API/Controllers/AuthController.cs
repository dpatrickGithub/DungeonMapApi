using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DungeonMap_API.Models;
using DungeonMap_API.Models.Auth;
using DungeonMap_API.Services;
using DungeonMap_API.Services.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DungeonMap_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration _configuration;
        private IUserService _userService;
        private IAuthService _authService;

        public AuthController(IConfiguration configuration, IUserService userService, IAuthService authService)
        {
            _configuration = configuration;
            _userService = userService;
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("token")]
        public IActionResult RequestToken([FromBody]TokenRequest request)
        {
            var user = _userService.GetUserByUsername(request.Username);
            if (user == null)
            {
                throw new Exception($"Unable to find a user with Username: {request.Username}");
            }


            if (!_authService.VerifyPassword(user.PasswordHash, user.Salt, request.Password))
            {
                return BadRequest("Could not verify username and password");
            }

            return Ok(new
            {
                Token = _authService.GenerateToken(request),
                UserId = user.Id
            });
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody]RegisterUserRequest request)
        {
            var salt = _authService.GenerateSalt();
            var hash = _authService.GenerateHash(request.Password, salt);

            var existingUser = _userService.GetUserByUsername(request.UserName);

            if (existingUser != null)
            {
                return BadRequest("this username is taken");
            }

            var user = new UserModel()
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PasswordHash = hash,
                Salt = Convert.ToBase64String(salt),
                UserName = request.UserName
            };

            var settings = new UserSettingsModel()
            {
                Biography = request.Biography,
                PreferredCharacterName = request.PreferredCharacterName,
                PhoneNumber = request.PhoneNumber,
                SkypeHandle = request.SkypeHandle,
                SubscriptionType = request.SubscriptionType
            };

            user = _userService.Create(user, settings);

            return Ok(user);
        }
    }
}
