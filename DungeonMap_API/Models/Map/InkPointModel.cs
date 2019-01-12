using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonMap_API.Models
{
    public class InkPointModel
    {
        public PointModel Position { get; set; }
        public float Pressure { get; set; }
        public float TiltX { get; set; }
        public float TiltY { get; set; }
        public ulong Timestamp { get; set; }
    }
}
