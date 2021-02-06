/**
    This file is Licensed under the MIT Licence
    Copyright (c) 2020 - 2021 Ethan James Patrick O'Donnell

    Authors: ejpo
**/

/// <summary>
/// A responder is a Discord user who is responsible for responding to tickets
/// This class tracks the users Discord Identity, the server that they are acting as a responder on behalf of and that users availability
/// </summary>

using System.Threading.Tasks;
using SaucyBot.Shared;

namespace SaucyBot.Ticketing
{
    public class Responder : BaseSaucyUser
    {
        protected bool _available;

        public Responder(ulong userID, ulong guildID)
        {
            Initialization = CreateAsync(userID,guildID);
        }

        /// <summary>
        /// Async helper method to create a new instance of responder
        /// </summary>
        /// <param name="userID">discord user UID</param>
        /// <param name="guildID">discord guild UID</param>
        /// <returns></returns>
        new protected Task<bool> CreateAsync(ulong userID, ulong guildID)
        {
            base.CreateAsync(userID, guildID);
            _available = false;
            // https://blog.stephencleary.com/2013/01/async-oop-2-constructors.html
            return Task.FromResult<bool>(true);
        }
        
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
