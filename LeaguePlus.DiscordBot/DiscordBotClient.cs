using Discord;
using Discord.Commands;
using Discord.WebSocket;
using LeaguePlus.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Threading.Tasks;
using Victoria;

namespace LeaguePlus.DiscordBot
{
    public class DiscordBotClient
    {
        #region Private Properties

        private readonly DiscordSocketClient _client;
        private IServiceProvider _services;
        private readonly ILogger _logger;
        private readonly CommandService _commands;
        private readonly DiscordEvents _events;
        //private readonly AudioService _audioService;

        #endregion

        #region Constructor

        public DiscordBotClient()
        {
            _logger = new ConsoleLogger();
            _logger.LogSuccessful("Initializing Discord Bot...");

            _client = new DiscordSocketClient(new DiscordSocketConfig {
                AlwaysDownloadUsers = true,
                DefaultRetryMode = RetryMode.AlwaysRetry,
                MessageCacheSize = 100,
                LogLevel = LogSeverity.Debug,
            });

            _events = new DiscordEvents();

            _commands = new CommandService(new CommandServiceConfig {
                LogLevel = LogSeverity.Debug,
                CaseSensitiveCommands = false,
            });
        }

        #endregion

        #region Public Methods

        public async Task InitializeAsync()
        {
            _services = SetupServices();
            await SetupDiscordClient();

            _logger.LogSuccessful("Successfully Initialized Bot!");

            await Task.Delay(-1);
        }

        private async Task SetupDiscordClient()
        {
            await _client.LoginAsync(TokenType.Bot, "NzUyMTA2OTAxODE0MTE2NDEy.X1S0Ig.wo9WEWdLHOMnBmjgNqWD6M5WEOg");
            await _client.SetStatusAsync(UserStatus.Online);
            await _client.SetGameAsync("League Plus", type: ActivityType.Watching);
            await _client.StartAsync();

            _client.Ready += _client_ReadyAsync;

            _client.MessageReceived += HandleCommandAsync;

            // Add the assembly for all discord modules for handling the commands
            await _commands.AddModulesAsync(Assembly.GetExecutingAssembly(), _services);
            //_client.Log += _client_Log;
            //_client.JoinedGuild += _client_JoinedGuild;
        }

        private async Task _client_ReadyAsync()
        {
            var _lavaNode = _services.GetService<LavaNode>();
            if(!_lavaNode.IsConnected)
            {
                _logger.LogInformation($"Trying to connect LavaNode");
                await _lavaNode.ConnectAsync();
            }
            _logger.LogSuccessful("Successfully connected Lava Node!");
            // Other ready related stuff
        }

        #endregion

        private IServiceProvider SetupServices() => new ServiceCollection()
            .AddSingleton(_client)
            .AddSingleton(_logger)
            .AddSingleton(_commands)
            .AddSingleton(_events)
            .AddLavaNode(x => {
                x.Hostname = "localhost";
                x.Port = 2333;
                x.Authorization = "";
                x.EnableResume = true;
                x.SelfDeaf = true;
            })
            .AddSingleton<AudioService>()
            .BuildServiceProvider();

        private async Task HandleCommandAsync(SocketMessage messsage)
        {
            var msg = messsage as SocketUserMessage;
            if (msg == null) return;

            int argPos = 0;

            // Determine if the message is a command based on the prefix and make sure no bots trigger commands
            if (!(msg.HasCharPrefix('!', ref argPos) || msg.HasMentionPrefix(_client.CurrentUser, ref argPos)) || msg.Author.IsBot)
                return;

            var context = new SocketCommandContext(_client, msg);

            await _commands.ExecuteAsync(context, argPos, _services);
        }

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
