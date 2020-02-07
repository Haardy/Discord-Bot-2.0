using System;
using System.IO;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Yorick.Command_Handler;
using Yorick.Command_Handler.Static_classes;

namespace Yorick
{
    class Program
    {
        static void Main(string[] args) => new Program().RunBotAsync().GetAwaiter().GetResult();

        private DiscordSocketClient _client;
        private SingletonCommands _singletonCommands;
        private IServiceProvider _services;

        public async Task RunBotAsync()
        {
           
            _singletonCommands = SingletonCommands.Instance;

            _client = new DiscordSocketClient();
            _services = new ServiceCollection()
                .AddSingleton(_client)
                .BuildServiceProvider();



            string token = "";

            using (StreamReader sr = new StreamReader("botToken.botToken"))
                token = sr.ReadLine();

            _client.Log += _client_Log;

            _client.MessageReceived += HandleCommandAsync;

            await _client.LoginAsync(TokenType.Bot, token);

            await _client.StartAsync();

            await Task.Delay(-1);
        }

        private Task _client_Log(LogMessage arg)
        {
            Console.WriteLine(arg);
            return Task.CompletedTask;
        }

        private async Task HandleCommandAsync(SocketMessage arg)
        {
            //tamere
            var message = arg as SocketUserMessage;
            var context = new SocketCommandContext(_client, message);

            int argPos = 0;
            if (message.Author.IsBot || message.Channel.Id != GuildIds.chatChannelId ||
                message.HasCharPrefix(SingletonCommands.CommandPrefix,ref argPos) == false) return;

            await _singletonCommands.TryRunCommandAsync(context);
        }
    }
}
