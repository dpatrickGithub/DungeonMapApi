using DungeonMap_API.Models;
using DungeonMap_Common;
using System.Collections.Generic;

namespace DungeonMap_API.Services.Character
{
    public interface ICharacterService
    {
        CharacterModel GetById(int id);
        CharacterModel GetCharacterByUserAndGame(int userId, int gameId);
        IEnumerable<CharacterModel> GetCharactersByUser(int userId);
        IEnumerable<IdNamePair> GetFriendsCharacters(int userId);
        void CreateCharacter(CharacterModel model);
    }
}