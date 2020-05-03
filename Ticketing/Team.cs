using Discord.WebSocket;
using System.Collections.Generic;

namespace SaucyBot.Ticketing
{
    class Team
    {
        private int identifier;
        private string name;
        private SocketGuild guild;
        private List<Responder> _responders;
    }
}