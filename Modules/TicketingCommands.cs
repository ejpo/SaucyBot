using System.Threading.Tasks;
using Discord.Commands;

namespace SaucyBot.Modules
{
    public class TicketingCommands : ModuleBase<SocketCommandContext>
    {

        private readonly Services.TicketingService _ticketingService;
        public TicketingCommands(Services.TicketingService ticketingService)
        {
            _ticketingService = ticketingService;
        }

        [Command("report")]
        async Task UserReportAsync()
        {
            await ReplyAsync("I will DM you shortly.\nPlease provide me with any extra information you can think of whilst you wait.");
        }

        [Command("newTicket")]
        async Task UserCreateNewChannelAsync()
        {
            await _ticketingService.CreateTicketChannelByCommand(Context.Message);
        }

        //@Testing - Create a new reposnder for the person who sent this message
        [Command("newResponder")]
        async Task CreateNewResponderAsync()
        {
            await _ticketingService.CreateNewRepsponderAsync(Context.Message.Author, Context.Guild);
        }

        //@Testing - Create a new team and add the sender as a responder
        [Command("newTeam")]
        async Task CreateNewTeamAsync()
        {
            await _ticketingService
        }
    }
}
