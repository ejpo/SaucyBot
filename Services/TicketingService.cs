using Discord.Commands;
using Discord.WebSocket;
using System.Collections.Generic;
using System.Threading.Tasks;
using SaucyBot.Ticketing;

namespace SaucyBot.Services
{
    public class TicketingService
    {
        private readonly DiscordSocketClient _discord;
        private readonly CommandService _commands;
        private readonly PrivateMessageHandler _pmHandler;
        private readonly TicketingFactory _factory;

        private Dictionary<ulong,Responder> _ticketResponders;

        public TicketingService(DiscordSocketClient discord,
        CommandService commands,
        PrivateMessageHandler pmHandler)
        {
            _discord = discord;
            _commands = commands;
            _ticketResponders = new Dictionary<ulong,Responder>();
            _factory = new TicketingFactory();
            _pmHandler = pmHandler;

            _discord.ChannelCreated += OnChannelCreated;

        }

        /**
        * Listener for new 
        */
        public async Task OnChannelCreated(SocketChannel s)
        {
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

        public async Task CreateNewRepsponderAsync(SocketUser identity, SocketGuild guild)
        {
            var myResponder = await _factory.CreateResponderAsync(identity, guild);
            try {
                _ticketResponders.Add(myResponder.SaucyID, myResponder);
            }
            catch {
                throw new System.Exception("Error adding ticket responder to collection");
            }
            
        }
    }
}
