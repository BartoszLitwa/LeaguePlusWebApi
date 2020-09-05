using Discord;
using Discord.Commands;
using Discord.WebSocket;
using LeaguePlus.Core;
using LeaguePlusWebApi;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Victoria;

namespace LeaguePlus.DiscordBot
{
    public class DiscordBotClient
    {
        #region Private Properties

        private readonly DiscordSocketClient _client;
        private IServiceProvider service;
        private readonly ILogger _logger;
        private readonly CommandService _commands; 

        #endregion

        #region Constructor

        public DiscordBotClient()
        {
            _client = new DiscordSocketClient(new DiscordSocketConfig {
                AlwaysDownloadUsers = true,
                MessageCacheSize = 50,
                LogLevel = LogSeverity.Debug,
            });

            _commands = new CommandService(new CommandServiceConfig {
                LogLevel = LogSeverity.Debug,
                CaseSensitiveCommands = false,
            });

            _logger = new FileLogger();
        }

        #endregion

        #region Public Methods

        public async Task InitializeAsync()
        {
            await SetupDiscordClient();
        }

        private async Task SetupDiscordClient()
        {
            await _client.LoginAsync(TokenType.Bot, "");
            await _client.SetStatusAsync(UserStatus.Online);
            await _client.SetGameAsync("League Plus", type: ActivityType.CustomStatus);
            await _client.StartAsync();

            _client.Log += _client_Log;
            _client.JoinedGuild += _client_JoinedGuild;
        }

        #endregion

        private IServiceProvider SetupServices() => new ServiceCollection()
            .AddSingleton(_client)
            .AddSingleton(_commands)
            .AddSingleton<LavaRestClient>()
            .BuildServiceProvider();

        private Task _client_JoinedGuild(SocketGuild arg)
        {
            throw new NotImplementedException();
        }

        private Task _client_Log(LogMessage arg)
        {
            throw new NotImplementedException();
        }
    }
}
