using DungeonMap_Common.Enums;

namespace DungeonMap_API.Services
{
    public interface IDiceService
    {
        int Roll(DieType dieSize, int count, int modifier);
    }
}