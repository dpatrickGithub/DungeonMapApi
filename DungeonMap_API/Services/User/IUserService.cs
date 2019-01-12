using DungeonMap_API.Models;

namespace DungeonMap_API.Services
{
    public interface IUserService
    {
        UserModel GetUserByUsername(string userName);
        UserModel Create(UserModel model, UserSettingsModel settingsModel);
    }
}