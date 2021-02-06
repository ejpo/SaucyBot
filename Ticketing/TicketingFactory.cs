/**
    This file is Licensed under the MIT Licence
    Copyright (c) 2020 - 2021 Ethan James Patrick O'Donnell

    Authors: ejpo
**/

using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace SaucyBot.Ticketing
{
   public class TicketingFactory
   {
       public TicketingFactory()
       {
           //Constructor shit goes here
       }

       public async Task<Responder> CreateResponderAsync(SocketUser identity, SocketGuild guild)
       {
           var newResponder = await Task.Run( () => ( new Responder(identity.Id, guild.Id) ) );
           await newResponder.Initialization;
           return newResponder;
       }

       public async Task<Team> CreateTeamAsync(string teamName, SocketGuild guild)
       {
           var newTeam = await Task.Run( () => ( new Team(teamName, guild.Id) ) );
           await newTeam.Initialization;
           return newTeam;
       }

        public async Task<Ticket> CreateTicketAsync()
        {
            throw new NotImplementedException();
        }
   }
}
