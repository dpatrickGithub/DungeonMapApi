using DungeonMap_Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonMap_API.Services
{
    public class DiceService : IDiceService
    {
        public int Roll(DieType dieSize, int count, int modifier)
        {
            var rng = new Random();
            var roll = rng.Next((int)dieSize);
            
            return (count * roll) + modifier;
        }
    }
}
