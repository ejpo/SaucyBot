using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SaucyBot.Services
{
    public class TicketingService
    {
        private readonly DiscordSocketClient _discord;
        private readonly CommandService _commands;

        private List<SocketUser> _ticketResponders;

        public List<SocketUser> TicketResponders{
            get{
                return _ticketResponders;
            }
        }

        public TicketingService(DiscordSocketClient discord, 
        CommandService commands)
        {
            _discord = discord;
            _commands = commands;
            _ticketResponders = new List<SocketUser>();
        }

        /*
            Adds a Discord user to the ticketResponder List.
            Pre-Condition: The user does not already exist in the list
            Post-Condition: The user will remain in the list until removed or until the bot restarts
        */
        public async Task AddTicketResponder(SocketUser responder)
        {
            if(!(_ticketResponders.Contains(responder))){
                await Task.Run(() => _ticketResponders.Add(responder));
            }
        }

        public async Task RemoveTicketResponder(SocketUser responder)
        {
            if(_ticketResponders.Contains(responder)){
                await Task.Run(() => _ticketResponders.Remove(responder));
            }
        }
    }
}