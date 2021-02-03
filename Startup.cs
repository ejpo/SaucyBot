/**
    Based heavily on the Discord.Net Example project by Github User Aux
    https://github.com/Aux/Discord.Net-Example

    Creates a project environemnt simillar to an ASP.NET web app
**/

using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SaucyBot.Data;

namespace SaucyBot
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(string[] args)
        {
            var builder = new ConfigurationBuilder()        // Create a new instance of the config builder
                .SetBasePath(AppContext.BaseDirectory)      // Specify the default location for the config file
                .AddYamlFile("_config.yml");                // Add this (yaml encoded) file to the configuration
            Configuration = builder.Build();                // Build the configuration
        }

        public static async Task RunAsync(string[] args)
        {
            var startup = new Startup(args);
            await startup.RunAsync();
        }

        public async Task RunAsync()
        {
            var services = new ServiceCollection();             // Create a new instance of a service collection
            ConfigureServices(services);

            var provider = services.BuildServiceProvider();     // Build the service provider
            provider.GetRequiredService<Services.LoggingService>();      // Start the logging service
            provider.GetRequiredService<Services.CommandHandler>(); 		// Start the command handler service
            provider.GetRequiredService<Services.TicketingService>();       //Start the ticketing service
            provider.GetRequiredService<Services.PrivateMessageHandler>();

            await provider.GetRequiredService<Services.StartupService>().StartAsync();       // Start the startup service
            await Task.Delay(-1);                               // Keep the program alive
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SaucyBotContext>(); //Setup the database

            services.AddSingleton(new DiscordSocketClient(new DiscordSocketConfig
            {                                       // Add discord to the collection
                LogLevel = LogSeverity.Verbose,     // Tell the logger to give Verbose amount of info
                MessageCacheSize = 1000             // Cache 1,000 messages per channel
            }))
            .AddSingleton(new CommandService(new CommandServiceConfig
            {                                       // Add the command service to the collection
                LogLevel = LogSeverity.Verbose,     // Tell the logger to give Verbose amount of info
                DefaultRunMode = RunMode.Async,     // Force all commands to run async by default
            }))
            .AddSingleton<Services.CommandHandler>()         // Add the command handler to the collection
            .AddSingleton<Services.StartupService>()         // Add startupservice to the collection
            .AddSingleton<Services.LoggingService>()         // Add loggingservice to the collection
            .AddSingleton<Services.PrivateMessageHandler>()
            .AddSingleton<Services.TicketingService>()       //Add the ticketingservice to the collection
            .AddSingleton<Random>()                 // Add random to the collection
            .AddSingleton(Configuration);           // Add the configuration to the collection
        }
    }
}
