using DungeonMap_API.Models;
using DungeonMap_API.Repositories;
using DungeonMap_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonMap_API.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepo;

        public UserService(IUserRepository userRepository)
        {
            _userRepo = userRepository;
        }

        public UserModel GetUserByUsername(string userName)
        {
            var user = _userRepo.GetUserByUserName(userName);
            if (user == null)
            {
                return null;
            }
            return new UserModel()
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PasswordHash = user.PasswordHash,
                Salt = user.Salt,
                UserName = user.UserName    
            };
        }

        public UserModel Create(UserModel model, UserSettingsModel settingsModel)
        {
            var user = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PasswordHash = model.PasswordHash,
                Salt = model.Salt,
                UserName = model.UserName,
                Settings = new UserSettings()
                {
                    PhoneNumber = settingsModel.PhoneNumber,
                    Biography = settingsModel.Biography,
                    PreferredCharacterName = settingsModel.PreferredCharacterName,
                    SkypeHandle = settingsModel.SkypeHandle,
                    SubscriptionType = settingsModel.SubscriptionType
                }
            };
            

            model.Id = _userRepo.CreateUser(user);

            return model;
        }
    }
}
