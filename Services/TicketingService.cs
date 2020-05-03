using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SaucyBot.Events;

namespace SaucyBot.Services
{
    public class TicketingService
    {
        private readonly DiscordSocketClient _discord;
        private readonly CommandService _commands;
        private readonly PrivateMessageHandler _pmHandler;

        private List<SocketUser> _ticketResponders;

        public List<SocketUser> TicketResponders{
            get{
                return _ticketResponders;
            }
        }

        public TicketingService(DiscordSocketClient discord, 
        CommandService commands, 
        PrivateMessageHandler pmHandler)
        {
            _discord = discord;
            _commands = commands;
            _ticketResponders = new List<SocketUser>();
            _pmHandler = pmHandler;

            _discord.ChannelCreated += OnChannelCreated;
            
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

        /**
        *   Signs a Discord user out of ticket notifications
        */
        public async Task RemoveTicketResponder(SocketUser responder)
        {
            if(_ticketResponders.Contains(responder)){
                await Task.Run(() => _ticketResponders.Remove(responder));
            }
        }
        /**
        * Listener for new 
        */
        public async Task OnChannelCreated(SocketChannel s){
            var channel = s as SocketDMChannel;

            await channel.SendMessageAsync("Channel Created");
        }

        public async Task OnChannelUpdated(SocketChannel s)
        {
            var channel = s as SocketDMChannel;
        }

        public async Task CreateTicketChannelByCommand(SocketUserMessage s)
        {
            var channel = s.Channel as SocketGuildChannel;
            await channel.Guild.CreateTextChannelAsync("Test");
	}
}
