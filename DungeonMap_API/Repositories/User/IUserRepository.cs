using DungeonMap_Entities;

namespace DungeonMap_API.Repositories
{
    public interface IUserRepository
    {
        User GetUserByUserName(string userName);
        int CreateUser(User user);
    }
}