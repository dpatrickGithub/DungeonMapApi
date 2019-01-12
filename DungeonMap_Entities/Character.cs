using DungeonMap_Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DungeonMap_Entities
{
    public class Character : EntityBase
    {
        [Required]
        public RoleType RoleType { get; set; }
        [Required]
        public int GameId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string CharacterName { get; set; }

        public Game Game { get; set; }
        public User User { get; set; }
    }
}
