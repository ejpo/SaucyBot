using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace SaucyBot
{
    class MessageListener : Listener
    {
        public MessageListener()
        {
        }

        /**
        *   Hooks into the Message Recieved _client EventHandler
        *   Sends messages to the services that should process the commands
        *   Differntiates between a 
        **/
        public async Task MessageProcessor(SocketMessage message)
        {
                if (message.Content.Equals("!ping")){
                    await message.Channel.SendMessageAsync("Pong mudda fucka");
                //Check to see if the Type IPrivateChannel is inherited by the object message.Channel (Is this a DM?)
                if(message.Channel is IPrivateChannel){
                    await message.Channel.SendMessageAsync("Ooh a DM! Making this personal i see?");
                }
            }
        }
    }
    
}