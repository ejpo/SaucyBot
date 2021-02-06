/**
    This file is Licensed under the MIT Licence
    Copyright (c) 2020 - 2021 Ethan James Patrick O'Donnell

    Authors: ejpo
**/

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