﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonMap_Entities
{
    public class UserFriend : EntityBase
    {
        public int UserId { get; set; }
        public int FriendId { get; set; }

        public User User { get; set; }
        public User Friend { get; set; }
    }
}
