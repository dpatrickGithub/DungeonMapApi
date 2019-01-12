using DungeonMap_API.Models;
using DungeonMap_API.Repositories;
using DungeonMap_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonMap_API.Services.Character
{
    public class CharacterService : ICharacterService
    {
        private ICharacterRepository _characterRepo;

        public CharacterService(ICharacterRepository characterRepository)
        {
            _characterRepo = characterRepository;
        }

        public CharacterModel GetCharacterByUserAndGame(int userId, int gameId)
        {
            var character = _characterRepo.GetCharacterByUserAndGame(userId, gameId);

            return new CharacterModel()
            {
                Id = character.Id,
                CharacterName = character.CharacterName,
                GameId = character.GameId,
                RoleType = character.RoleType,
                UserId = character.UserId
            };
        }

        public IEnumerable<CharacterModel> GetCharactersByUser(int userId)
        {
            var characters = _characterRepo.GetCharactersByUserId(userId).Select(c => new CharacterModel()
            {
                CharacterName = c.CharacterName,
                GameId = c.GameId,
                GameName = c.Game.Name,
                Id = c.Id,
                RoleType = c.RoleType,
                UserId = c.UserId
            });

            return characters;
        }

        public IEnumerable<IdNamePair> GetFriendsCharacters(int userId)
        {
            return _characterRepo.GetUserFriendsCharacters(userId).Select(x => new IdNamePair()
            {
                Id = x.Id,
                Name = x.CharacterName + " | " + x.User.UserName
            });
        }

        public CharacterModel GetById(int id)
        {
            var entity = _characterRepo.GetById(id);
            return new CharacterModel()
            {
                Id = entity.Id,
                CharacterName = entity.CharacterName,
                GameId = entity.GameId,
                GameName = entity.Game.Name,
                RoleType = entity.RoleType,
                UserId = entity.UserId
            };
        }
    }
}
