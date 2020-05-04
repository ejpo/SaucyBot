/// <summary>
/// A responder is a Discord user who is responsible for responding to tickets
/// This class tracks the users Discord Identity, the server that they are acting as a responder on behalf of and that users availability
/// </summary>

using System.Threading.Tasks;
using Discord.WebSocket;
using SaucyBot.Shared;

namespace SaucyBot.Ticketing
{
    class Responder : IAsyncIntialization
    {
        private SocketUser _identity;

        //TODO Do we need this?
        private SocketGuild _server;

        private bool _available;

        private bool _intialized;

        /// <summary>
        /// Availability of the responder to respond to a ticker
        /// </summary>
        /// <value>Boolean, can or cannot respond (respectively true,false)</value>
        public bool Available
        {
            get{
                return _available;
            }
            set{
                _available = value;
            }
        }

        public Task<bool> Initialization
        {
            get;
            private set;
        }

        /// <summary>
        /// Constrcutor for Responders, by default all responders start off as unavailable.
        /// </summary>
        /// <param name="identity">The SocketUser object for this paticulkar responder</param>
        /// <param name="server">The guild that the SocketUser will be acting as a repsponder on behalf of</param>
        public Responder(SocketUser identity, SocketGuild server)
        {
            Initialization = CreateAsync(identity, server);
        }

        public Task<bool> CreateAsync(SocketUser identity, SocketGuild server)
        {
            _identity = identity;
            _server = server;
            _available = false;
            // https://blog.stephencleary.com/2013/01/async-oop-2-constructors.html
            return Task.FromResult<bool>(true);
        }

        public Task<SocketUser> GetAsyncIdentity()
        {
            return Task.FromResult<SocketUser>(_identity);
        }

        /// <summary>
        /// Getter for Responder Server
        /// </summary>
        /// <value>SocketGuild that this responder replies on behalf of</value>
        public SocketGuild Server
        {
            get{
                return _server;
            }
        }

        //public

    }
}
