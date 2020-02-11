using System.Threading;
using System.Threading.Tasks;
using Discord.Commands;

namespace SaucyBot.Modules
{
    public class TestCommands : ModuleBase<SocketCommandContext>
    {
        [Command("ping")]
        async Task AsyncPing()
        {
            await ReplyAsync("pong");
        }       
    }
}