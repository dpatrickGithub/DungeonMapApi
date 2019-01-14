using DungeonMap_Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonMap_API.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly DungeonMapContext _context;

        public GameRepository(DungeonMapContext context)
        {
            _context = context;
        }

        public IEnumerable<Game> GetGamesByCharacter(int characterId)
        {
            var games = _context.Games.Include(x => x.Characters).Where(g => g.Characters.Any(x => x.Id == characterId));

            return games.AsEnumerable();
        }

        public void Create(Game game)
        {
            _context.Add(game);
            _context.SaveChanges();
        }

        public IEnumerable<Game> GetFriendsGames(int userId)
        {
            var friendsCharacters = _context.UserFriends.Include(uf => uf.Friend).Include(uf => uf.Friend.Characters).Where(uf => uf.UserId == userId).SelectMany(uf => uf.Friend.Characters);
            return friendsCharacters.Include(ch => ch.Game).Select(ch => ch.Game);
        }
    }
}
