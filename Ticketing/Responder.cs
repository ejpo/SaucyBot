/// <summary>
/// A responder is a Discord user who is responsible for responding to tickets
/// This class tracks the users Discord Identity, the server that they are acting as a responder on behalf of and that users availability
/// </summary>

using System.Threading.Tasks;
using SaucyBot.Shared;

namespace SaucyBot.Ticketing
{
    public class Responder : IAsyncIntialization
    {
        //unique identifier for a responder, calculated based on user ID and server ID
        private ulong _responderID;
        private ulong _userID;
        private ulong _guildID;
        private bool _available;

        /// <summary>
        /// Construcutor for Responders, by default all responders start off as unavailable.
        /// Unless you know what you are doing, you should create responder objects using an instance of TicketingFactory
        /// </summary>
        /// <param name="userID">The ulond id for this paticular responders Socket UserObject</param>
        /// <param name="guildID">The ulong id for the guild that the user is operating in the context of</param>
        public Responder(ulong userID, ulong guildID)
        {
            Initialization = CreateAsync(userID, guildID);
        }
        
        /// <summary>
        /// Property to track whether this object is initialised yet
        /// Used when a Responder is constructed asynchronouly
        /// </summary>
        /// <value>True when object is ready to be used or False when the object is still being intialised </value>
        public Task<bool> Initialization
        {
            get;
            private set;
        }

        /// <summary>
        /// Async helper method to create a new instance of responder
        /// </summary>
        /// <param name="userID">discord user UID</param>
        /// <param name="guildID">discord guild UID</param>
        /// <returns></returns>
        private Task<bool> CreateAsync(ulong userID, ulong guildID)
        {
            _userID = userID;
            _guildID = guildID;
            _available = false;
            // https://blog.stephencleary.com/2013/01/async-oop-2-constructors.html
            return Task.FromResult<bool>(true);
        }

        /// <summary>
        /// ID for the user that is represented by this Responder object 
        /// </summary>
        /// <value>ulong - discord user uid</value>
        public ulong UserID { get { return _userID; } }

        /// <summary>
        /// ID for the guild that this user is operating in the context of
        /// </summary>
        /// <value>ulong - discord guild uid</value>
        public ulong GuildID { get { return _guildID; } }
        
        /// <summary>
        /// Availability of the responder to respond to a ticket
        /// </summary>
        /// <value>Boolean - can or cannot respond (respectively true,false)</value>
        public bool Available
        { 
            get { return _available; } 
            set { _available = value; }
        }

    }
}
