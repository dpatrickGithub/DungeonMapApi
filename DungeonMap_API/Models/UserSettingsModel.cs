using DungeonMap_Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonMap_API.Models
{
    public class UserSettingsModel
    {
        public string PreferredCharacterName { get; set; }
        public string PhoneNumber { get; set; }
        public string Biography { get; set; }
        public string SkypeHandle { get; set; }
        public SubscriptionType SubscriptionType { get; set; }
    }
}
