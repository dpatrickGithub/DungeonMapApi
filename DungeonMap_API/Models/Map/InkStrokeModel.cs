using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonMap_API.Models
{
    public class InkStrokeModel
    {
        public IReadOnlyCollection<InkPointModel> InkPoints { get; set; }
        public ColorModel Color { get; set; }
        public int PenSize { get; set; }
    }
}
