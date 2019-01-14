using DungeonMap_Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonMap_API.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly DungeonMapContext _context;

        public CharacterRepository(DungeonMapContext context)
        {
            _context = context;
        }

        public Character GetById(int id)
        {
            return _context.Characters.Include(ch => ch.Game).Single(ch => ch.Id == id);
        }

        public IEnumerable<Character> GetCharactersByUserId(int userId)
        {
            var characters = _context.Characters.Include(x => x.Game).Where(c => c.UserId == userId);

            return characters;
        }

        public Character GetCharacterByUserAndGame(int userId, int gameId)
        {
            var character = GetCharactersByUserId(userId).Single(ch => ch.GameId == gameId);
            return character;
        }

        public IEnumerable<Character> GetUserFriendsCharacters(int userId)
        {
            var characters = _context.UserFriends.Include(x => x.Friend).Include(x => x.Friend.Characters).Where(uf => uf.UserId == userId).SelectMany(uf => uf.Friend.Characters);
            return characters.Where(c => c.GameId == default(int)); //Get only characters without an active game.
        }

        public void Create(Character character)
        {
            _context.Add(character);
            _context.SaveChanges();
        }
    }
}
