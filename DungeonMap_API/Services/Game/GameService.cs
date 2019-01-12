using DungeonMap_API.Models;
using DungeonMap_API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonMap_API.Services
{
    public class GameService : IGameService
    {
        private readonly ICharacterRepository _characterRepo;
        private readonly IGameRepository _gameRepo;

        public GameService(ICharacterRepository characterRepository, IGameRepository gameRepository)
        {
            _characterRepo = characterRepository;
            _gameRepo = gameRepository;
        }

        public IEnumerable<GameModel> GetGamesByUserId(int userId)
        {
            var userCharacters = _characterRepo.GetCharactersByUserId(userId);

            var games = new List<GameModel>();

            foreach (var character in userCharacters)
            {
                var gamesByChar = _gameRepo.GetGamesByCharacter(character.Id).Select(g => new GameModel
                {
                    Characters = new List<CharacterModel>()
                    {
                        new CharacterModel
                        {
                            Id = character.Id,
                            CharacterName = character.CharacterName,
                            GameId = character.GameId,
                            RoleType = character.RoleType,
                            UserId = character.UserId
                        }
                    },
                    GameType = g.GameType,
                    Name = g.Name,
                    IsActive = true
                });

                games.AddRange(gamesByChar);
            }

            return games;
        }
    }
}
