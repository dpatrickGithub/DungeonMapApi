using System.Collections.Generic;
using DungeonMap_API.Models;
using DungeonMap_Common;

namespace DungeonMap_API.Services
{
    public interface IGameService
    {
        void CreateGame(GameModel game);
        IEnumerable<GameModel> GetGamesByUserId(int userId);
        IEnumerable<GameUserModel> GetFriendsGames(int userId);
    }
}