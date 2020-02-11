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

        [Command("ticketLogin")]
        async Task UserLoginAsync()
        {
            var ticketingService1 = _ticketingService;
            var author = Context.Message.Author;
            await _ticketingService.AddTicketResponder(Context.Message.Author);
            await ReplyAsync("You have been logged in to the ticketing system.");
        }

        [Command("ticketLogout")]
        async Task UserLogoutAsync()
        {
            await _ticketingService.RemoveTicketResponder(Context.Message.Author);
            await ReplyAsync("You have been logged out of the ticketing system.");
        }
    }
}