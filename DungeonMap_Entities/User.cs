using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonMap_Entities
{
    public class User : EntityBase
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }

        public UserSettings Settings { get; set; }

        public ICollection<Character> Characters { get; set; }
        public ICollection<UserFriend> UserFriends { get; set; }
        public ICollection<UserFriend> FriendUsers { get; set; }
    }
}
