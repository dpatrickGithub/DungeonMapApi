using DungeonMap_Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DungeonMap_Entities
{
    public class Game : EntityBase
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public GameType GameType { get; set; }

        public ICollection<Character> Characters { get; set; }
    }
}
