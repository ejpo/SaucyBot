using System;
using System.Threading;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Discord;
using Discord.WebSocket;
using Discord.Commands;

namespace SaucyBot
{
    //@TODO: FATTY ONE!!! ReWrite the bot be based entirele upon the Service Based Property Dependedency injection model!!!!
    // https://github.com/Aux/Discord.Net-Example/blob/2.0/src/Services/StartupService.cs
    class SaucyBotMain
    {
        private readonly DiscordSocketClient _client;
        private readonly CommandService _commands;

        private readonly IServiceProvider _services;
        private static String _token;
        public String Token
        {
            get
            {
                return _token;
            }
        }
        public SaucyBotMain()
        {
            _client = new DiscordSocketClient(new DiscordSocketConfig {
                LogLevel = LogSeverity.Info,
                MessageCacheSize = 100
            });

            _commands = new CommandService(new CommandServiceConfig {
                LogLevel = LogSeverity.Info,
                CaseSensitiveCommands = false
            });

            _services = ConfigureServices();
        }

        private IServiceProvider ConfigureServices()
        {
            var serviceMap = new ServiceCollection()
                .AddSingleton<Services.CommandHandler>();
            
            return serviceMap.BuildServiceProvider();
        }

        /**
        * Entrypoint starts imediately in the Main Async context of MainAsync()
        * All bot call will be async so everything running runs in an async context
        **/
        public static void Main(string[] args)
        {
            //@TODO: Janky token assignment, read from config file or env variable. For Dev use only atm!!!
            if (args.Length > 0)
            {
                _token = args[0];
            }
            else
            {
                _token = null;
            }

            new SaucyBotMain().MainAsync().GetAwaiter().GetResult();
        }

        /**
        * Main Async thread called by lambda off of main
        * Bot initialised here
        * Prevent the task from completing by delaying returning for an infinte period of time
        */
        public async Task MainAsync()
        {

            await Init();
            await Task.Delay(-1);
        }

        /* 
            Method to initialize the main control structures for the bot
            _client - the main logic for the discord bot
            _commands - the command handler for the discord bot
            _services - the service manager for services provided to the bot

            Calls the authentication and event listner subscription methods
         */
        private async Task Init()
        {
            SubscribeListners();

            await InstallCommandsAsync();

            await Login();
            await _client.StartAsync();
        }

        /*
            Method to authenticate the bot to the discord API
            The API token is read from an enviroment variable, "DiscordToken", which must be initialsed in the same scope the program is launched from 
         */
        private async Task Login()
        {
            if (this.Token == null)
            {
                await _client.LoginAsync(TokenType.Bot, Environment.GetEnvironmentVariable("DiscordToken"));
            }
            else
            {
                await _client.LoginAsync(TokenType.Bot, this.Token);
            }
        }

        /* 
            Method to subscribe the inital EventListners
            @TODO: Replace this call with a logging service
         */
        private void SubscribeListners()
        {
            _client.Log += Log;
        }

        public async Task InstallCommandsAsync()
        {
            // Here we discover all of the command modules in the entry 
            // assembly and load them. Starting from Discord.NET 2.0, a
            // service provider is required to be passed into the
            // module registration method to inject the 
            // required dependencies.
            //
            // If you do not use Dependency Injection, pass null.
            // See Dependency Injection guide for more information.
            await _commands.AddModulesAsync(assembly: Assembly.GetEntryAssembly(),
                                            services: null);
        }

        /**
        * @TODO: MOve this to the Logging Service
        * Logging event handler, bound to _client.Log
        */
        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}
