using DungeonMap_Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DungeonMap_Entities
{
    public class UserSettings : EntityBase
    {
        public string PreferredCharacterName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string Biography { get; set; }
        public string SkypeHandle { get; set; }
        [Required]
        public SubscriptionType SubscriptionType { get; set; }

        public User User { get; set; }
    }
}
