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
    }
}
