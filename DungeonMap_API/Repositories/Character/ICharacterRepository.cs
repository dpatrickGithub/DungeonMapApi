using System.Collections.Generic;
using DungeonMap_Entities;

namespace DungeonMap_API.Repositories
{
    public interface ICharacterRepository
    {
        Character GetById(int id);
        IEnumerable<Character> GetCharactersByUserId(int userId);
        Character GetCharacterByUserAndGame(int userId, int gameId);
        IEnumerable<Character> GetUserFriendsCharacters(int userId);
        void Create(Character character);
    }
}