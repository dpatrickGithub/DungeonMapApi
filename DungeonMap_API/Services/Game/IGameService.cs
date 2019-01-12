using System.Collections.Generic;
using DungeonMap_API.Models;

namespace DungeonMap_API.Services
{
    public interface IGameService
    {
        IEnumerable<GameModel> GetGamesByUserId(int userId);
    }
}