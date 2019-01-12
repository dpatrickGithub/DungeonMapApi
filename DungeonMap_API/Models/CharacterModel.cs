using DungeonMap_Common.Enums;

namespace DungeonMap_API.Models
{
    public class CharacterModel
    {
        public int Id { get; set; }
        public RoleType RoleType { get; set; }
        public int GameId { get; set; }
        public int UserId { get; set; }
        public string GameName { get; set; }
        public string CharacterName { get; set; }
    }
}