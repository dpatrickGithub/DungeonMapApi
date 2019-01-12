using DungeonMap_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DungeonMap_API.Hubs
{
    public interface IMapClient
    {
        Task StrokesAdded(IDictionary<uint, InkStrokeModel> inkStrokes);
        Task StrokesRemoved(uint strokeId);
    }
}