using System.Collections.Generic;
using DungeonMap_Entities;

namespace DungeonMap_API.Repositories
{
    public interface IGameRepository
    {
        void Create(Game game);
        IEnumerable<Game> GetGamesByCharacter(int characterId);
        IEnumerable<Game> GetFriendsGames(int userId);
    }
}