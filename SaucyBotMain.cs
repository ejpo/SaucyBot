/**
    This file is Licensed under the MIT Licence
    Copyright (c) 2020 - 2021 Ethan James Patrick O'Donnell

    Authors: ejpo
    
    Based heavily on the Discord.Net Example project by Github User Aux
    https://github.com/Aux/Discord.Net-Example

    Creates a project environemnt simillar to an ASP.NET web app
**/

using System.Threading.Tasks;
namespace SaucyBot
{
    class SaucyBotMain
    {
        /**
        * Entrypoint starts imediately in the Main Async context of RunAsync()
        * All bot call will be async so everything running runs in an async context
        **/
        public static Task Main(string[] args)
            => Startup.RunAsync(args);
    }
}