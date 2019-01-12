using System.Collections.Generic;
using DungeonMap_Entities;

namespace DungeonMap_API.Repositories
{
    public interface IGameRepository
    {
        IEnumerable<Game> GetGamesByCharacter(int characterId);
    }
}