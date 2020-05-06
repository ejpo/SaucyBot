using Discord.WebSocket;
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
           Responder newResponder = new Responder(identity.Id, guild.Id);
           await newResponder.Initialization;
           return newResponder;
       }
   }
}
