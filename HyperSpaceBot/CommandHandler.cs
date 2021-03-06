﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;
using Discord.Commands;
using System.Reflection;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace HyperSpaceBot
{
    class CommandHandler
    {
        private DiscordSocketClient _client;
        private CommandService _service;
        private char _prefix = '.';


        public CommandHandler(DiscordSocketClient client)
        {
            _client = client;
            _service = new CommandService();
            _service.AddModulesAsync(Assembly.GetEntryAssembly());
            _client.MessageReceived += HandleCommandAsync;
        }

        private async Task HandleCommandAsync(SocketMessage message)
        {
            var msg = message as SocketUserMessage;
            if (msg == null) return;
            var context = new SocketCommandContext(_client, msg);
            int argPos = 0;

            //Spy stuff
            if (context.Channel.Name == "general")
            {
                string mssg = msg.Content;
                var server = context.Guild.Name;
                var channel = message.Channel;
                var user = message.Author;
                string time = message.CreatedAt.ToString();
                string timecut = time.Remove(time.Length - 7);
                var guild = _client.GetGuild(407596076623986689);
                var channelTo = guild.GetTextChannel(407601514148921345);
                string result = "**|-----------------------------------------------------|**" +
                  "\n**User:** " + user + "\n**Time:** " + timecut + "\n**Server:** "
                  + server + "\n**Channel:** " + channel + "\n**Message:** " + mssg;

                    await channelTo.SendMessageAsync(result);

                //Writes logs to a file
                string write = "User: " + user + " | Time: " + timecut + " | Server: "
                  + server + " | Channel: " + channel + " | Message: " + mssg;
                string[] lines = {write};
                File.AppendAllLines(@"F:\.GitHub Repo\HyperSpaceBot\logs.txt", lines);
            }
            //End of spy stuff
            if (msg.HasCharPrefix(_prefix, ref argPos) || msg.HasMentionPrefix(_client.CurrentUser, ref argPos))
            {
                var result = await _service.ExecuteAsync(context, argPos);
                if(!result.IsSuccess && result.Error != CommandError.UnknownCommand)
                {
                    await context.Channel.SendMessageAsync(result.ErrorReason);
                }
            }
        }
    }
}
