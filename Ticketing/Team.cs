/**
    This file is Licensed under the MIT Licence
    Copyright (c) 2020 - 2021 Ethan James Patrick O'Donnell

    Authors: ejpo
**/

using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using SaucyBot.Interfaces;
namespace SaucyBot.Ticketing
{
    public class Team : IAsyncIntialization
    {
        private ulong _teamID;
        private String _teamName;
        private ulong _guildID;
        private Dictionary<ulong,Responder> _teamResponders;

        public Task<bool> Initialization { get; private set; }

        public Team(string name, ulong guildID)
        {
            Initialization = CreateAsync(name, guildID);
        }

        private Task<bool> CreateAsync(string name, ulong guildID)
        {
            _teamName = name;
            _guildID = guildID;
            _teamID = DeriveTeamID();
            _teamResponders = new Dictionary<ulong, Responder>();

            return Task.FromResult<bool>(true);
        }

        private ulong DeriveTeamID()
        {
            ulong uid = 57;
            uid = uid * ulong.Parse(_teamName.ToCharArray()) / 12;
            uid = uid * _guildID / 12;

            return uid;
        }

        public Task<bool> AddResponder(Responder responder)
        {
            try
            {
                if( !(_teamResponders.ContainsKey(responder.SaucyID)) ){
                    _teamResponders.Add(responder.SaucyID, responder);
                }
                return Task.FromResult<bool>(true);
            }
            catch (System.Exception)
            {
                return Task.FromResult<bool>(false);
            }
        }

        public Task<bool> RemoveResponder(Responder responder)
        {
            try
            {
                if(_teamResponders.ContainsKey(responder.SaucyID)){
                    _teamResponders.Remove(responder.SaucyID);
                }
                return Task.FromResult<bool>(true);
            }
            catch (System.Exception)
            {
                return Task.FromResult<bool>(false);
            }
        }

        
    }
}