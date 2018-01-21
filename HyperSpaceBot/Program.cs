using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace HyperSpaceBot
{
    class Program
    {
        private DiscordSocketClient _client;
        private string _token = "NDA0MzI4NTUxMjg3MDk1MzA2.DUUhvA.5LTNTWUoaicDAtMEHul-_mbW5kA";
        private CommandHandler _handler;
        static void Main(string[] args)
        => new Program().StartAsync().GetAwaiter().GetResult();

        public async Task StartAsync()
        {
            _client = new DiscordSocketClient();
            _handler = new CommandHandler(_client);
            await _client.LoginAsync(TokenType.Bot, _token);
            await _client.StartAsync();
            await Task.Delay(-1);
        }

     
    }
}
