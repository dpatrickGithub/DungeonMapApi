using DungeonMap_Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonMap_API.Models
{
    public class GameModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GameType GameType { get; set; }
        public bool IsActive { get; set; }

        public ICollection<CharacterModel> Characters { get; set; }
    }
}
