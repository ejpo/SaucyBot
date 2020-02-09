using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace SaucyBot
{
    class SaucyBotMain
    {
        private DiscordSocketClient _client;
        private MessageListener _messageListener;
        private static String token;
        
        /**
        * @author: Ethan O'Donnell
        * Entrypoint starts imediately in the Main Async context of MainAsync()
        * All bot call will be async so everything running runs in an async context
        **/
        static void Main(string[] args)
        {
            //@TODO: Janky token assignment, read from config file or env enviroment. For Dev use only atm!!!
            if (args.Length > 0){
                token = args[0];
            } else {
                token = null;
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
            _client = new DiscordSocketClient();
            _messageListener = new MessageListener();

            SubscribeListners();
            
            await Login();
            await _client.StartAsync();
        }

        private void token{}

        /*
            Method to authenticate the bot to the discord API
            The API token is read from an enviroment variable, "DiscordToken", which must be initialsed in the same scope the program is launched from 
         */
        private async Task Login()
        {
            String discordToken;
            
            setToken();
            await _client.LoginAsync(TokenType.Bot,Environment.GetEnvironmentVariable("DiscordToken"));
        }

        /* 
            Method to subscribe the inital EventListners
         */
        private void SubscribeListners()
        {
            _client.Log += Log;
            _client.MessageReceived += _messageListener.MessageReceived;
        }

        /**
        * Logging event handler, bound to _client.Log
        */
        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}
