/**
    This file is Licensed under the MIT Licence
    Copyright (c) 2020 - 2021 Ethan James Patrick O'Donnell

    Authors: ejpo
**/
using System;
using System.Threading.Tasks;
using Discord.WebSocket;
using SaucyBot.Events;


namespace SaucyBot.Services
{
    public class PrivateMessageHandler
    {
        private readonly DiscordSocketClient _discord;
        //public event EventHandler<PMArgs> PMRecieved;

        public PrivateMessageHandler(DiscordSocketClient discord)
        {
            _discord = discord;
            _discord.MessageReceived += OnMessageRecieivedAsync;
        }

        private async Task OnMessageRecieivedAsync(SocketMessage s)
        {
            var msg = s as SocketUserMessage;     // Ensure the message is from a user/bot

            if (msg == null) return;
            if (msg.Author.Id == _discord.CurrentUser.Id) return;     // Ignore self when checking commands

            if (msg.Channel is ISocketPrivateChannel)
            {
                await msg.Channel.SendMessageAsync("Private");
            }
        }
    }
}