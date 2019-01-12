using DungeonMap_API.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonMap_API.Hubs
{
    public class MapHub : Hub<IMapClient>
    {
        public async Task AddStrokes(IDictionary<uint, InkStrokeModel> inkStrokes)
        {
            Console.Write(inkStrokes);
            await Clients.All.StrokesAdded(inkStrokes);
        }

        public async Task DeleteStrokes(uint strokeId)
        {
            Console.Write(strokeId);
            await Clients.All.StrokesRemoved(strokeId);
        }
    }
}
