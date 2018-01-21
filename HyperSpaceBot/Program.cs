using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using System.IO;

namespace HyperSpaceBot
{
    class Program
    {
        private DiscordSocketClient _client;
        private string _token = "";
        private CommandHandler _handler;
        static void Main(string[] args)
        => new Program().StartAsync().GetAwaiter().GetResult();

        public async Task StartAsync()
        {
            _client = new DiscordSocketClient();
            _handler = new CommandHandler(_client);

            try
            {
                StreamReader sr = new StreamReader("config.txt");
                _token = sr.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
       
            await _client.LoginAsync(TokenType.Bot, _token);
            await _client.StartAsync();
            await Task.Delay(-1);
        }

     
    }
}
