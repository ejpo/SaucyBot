/**
    This file is Licensed under the MIT Licence
    Copyright (c) 2020 - 2021 Ethan James Patrick O'Donnell

    Authors: ejpo
**/
using System.Threading.Tasks;
using SaucyBot.Interfaces;

namespace SaucyBot.Shared
{
    public abstract class BaseSaucyUser : IAsyncIntialization
    {
        protected ulong _saucyID;
        protected ulong _userID;
        protected ulong _guildID;

        /// <summary>
        /// Property to track whether this object is initialised yet
        /// Used when a derived object is constructed asynchronouly
        /// </summary>
        /// <value>True when object is ready to be used or False when the object is still being intialised </value>
        public Task<bool> Initialization
        {
            get;
            protected set;
        }

        /// <summary>
        /// Async helper method to fill out the inherited fields of a derived object, should contain an overding method that calls this base method
        /// And uses the overiding method to set it's non-derived fields like a constructor.
        /// 
        /// The constructor for a derived method should set Initiailized = CreateAsync(i,k);
        /// </summary>
        /// <param name="userID">discord user UID</param>
        /// <param name="guildID">discord guild UID</param>
        /// <returns></returns>
        protected Task<bool> CreateAsync(ulong userID, ulong guildID)
        {
            _userID = userID;
            _guildID = guildID;
            _saucyID = DeriveSaucyID();

            return Task.FromResult<bool>(true);
        }

        /// <summary>
        /// Generate a uid derived from the discord user UID and the discord guild UID
        /// Used to later search for the User in any structs it's stored in, doesn't neeed to be foolproof and avoid collision as
        /// I think the space for possible UID's is large enough that this won't matter. Might regret this decision
        /// </summary>
        /// <returns></returns>
        protected ulong DeriveSaucyID()
        {
            ulong uid = 57;
            uid = uid * _userID / 12;
            uid = uid * _guildID / 12;

            return uid;
        }

        /// <summary>
        /// Unique ID derived from Discord User UID and Discord Guild UID
        /// </summary>
        /// <value>ulong - SaucyBot Saucy ID</value>
        public ulong SaucyID { get { return _saucyID; } } 

        /// <summary>
        /// ID for the user that is represented by this User object 
        /// </summary>
        /// <value>ulong - discord user uid</value>
        public ulong UserID { get { return _userID; } }

        /// <summary>
        /// ID for the guild that this user is operating in the context of
        /// </summary>
        /// <value>ulong - discord guild uid</value>
        public ulong GuildID { get { return _guildID; } }

    }
}