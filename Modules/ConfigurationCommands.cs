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
            throw new NotImplementedException();
        }

        [Command("configTicketingChannel")]
        async Task SetTicketingChannelAsync()
        {
            throw new NotImplementedException();
        }
        [Command("configAddRole")]
        async Task AddAdministaraiveRole()
        {
            throw new NotImplementedException();
        }
        [Command("configRemoveRole")]
        async Task RemoveAdministrativeRole()
        {
            throw new NotImplementedException();
        }
    }
}