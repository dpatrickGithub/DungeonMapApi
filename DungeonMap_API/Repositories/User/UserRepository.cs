using DungeonMap_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonMap_API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DungeonMapContext _context;

        public UserRepository(DungeonMapContext context)
        {
            _context = context;
        }

        public User GetUserByUserName(string userName)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName.ToLower() == userName.ToLower());
            return user;
        }

        public int CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.UserSettings.Add(user.Settings);

            _context.SaveChanges();

            return user.Id;
        }
    }
}
