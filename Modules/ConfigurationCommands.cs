/**
    This file is Licensed under the MIT Licence
    Copyright (c) 2020 - 2021 Ethan James Patrick O'Donnell

    Authors: ejpo
**/

using System;
using System.Threading.Tasks;
using Discord.Commands;

namespace SaucyBot.Modules
{
    [RequireOwner]
    public class ConfigurationCommands : ModuleBase<SocketCommandContext>
    {
        [Command("configReportChannel")]
        async Task SetReportChannelAsync()
        {
            await Console.Out.WriteLineAsync("No Implementation for this yet");
            throw new NotImplementedException();
        }

        [Command("configTicketingChannel")]
        async Task SetTicketingChannelAsync()
        {
            await Console.Out.WriteLineAsync("No Implementation for this yet");
            throw new NotImplementedException();
        }
        [Command("configAddRole")]
        async Task AddAdministaraiveRole()
        {
            await Console.Out.WriteLineAsync("No Implementation for this yet");
            throw new NotImplementedException();
        }
        [Command("configRemoveRole")]
        async Task RemoveAdministrativeRole()
        {
            await Console.Out.WriteLineAsync("No Implementation for this yet");
            throw new NotImplementedException();
        }
    }
}