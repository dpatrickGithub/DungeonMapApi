using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonMap_API.Models
{
    public class GameUserModel
    {
        public int GameId { get; set; }
        public string GameName { get; set; }
        public string UserName { get; set; }
    }
}
