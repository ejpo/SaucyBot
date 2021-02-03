using Discord.WebSocket;
using System.Threading.Tasks;
using System;
using SaucyBot.Interfaces;

namespace SaucyBot.Ticketing
{
    public class Ticket : IAsyncIntialization
    {
        private ulong _ticketID;
        private Team _ticketTeam; //Team derived from database by Team ID?
        private int _ticketState; //Enum Ticket State for numbers innit!
        private Discord.IChannel _ticketChannel;
        private DateTime _ticketOpenTime;
        private DateTime _ticketClosed;

        public Task<bool> Initialization { get; private set; }

        public Ticket()
        {
            Initialization = this.CreateAsync();
        }

        private Task<bool> CreateAsync()
        {
            throw new NotImplementedException();
        }
    }
}
