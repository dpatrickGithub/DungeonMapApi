using DungeonMap_API.Services;
using DungeonMap_Common.Enums;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonMap_API.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IDiceService _diceService; 

        public ChatHub(IDiceService diceService)
        {
            _diceService = diceService;
        }

        public async Task Send(string userName, string message)
        {
            await Clients.All.SendAsync("Send", userName, message);
            var lowerCaseMessage = message.ToLowerInvariant();

            if (lowerCaseMessage.StartsWith("/roll ") || lowerCaseMessage.StartsWith("/gmroll "))
            {
                var messageContents = lowerCaseMessage.Split(" ");
                var dieMessageCollection = messageContents.ElementAt(1).Split('d');

                var count = Convert.ToInt32(dieMessageCollection.First());
                var dieSize = (DieType)Convert.ToInt32(dieMessageCollection.Last());
                int modifier = GetModifier(messageContents);

                await Clients.All.SendAsync("SendDiceRoll", userName, _diceService.Roll(dieSize, count, modifier));
            }
        }

        private int GetModifier(string[] messageContents)
        {
            var modifier = 0;

            foreach (var item in messageContents)
            {
                if (item.StartsWith("+"))
                {

                    modifier += Convert.ToInt32(item.Substring(1));
                }
            }

            return modifier;
        }
    }
}
