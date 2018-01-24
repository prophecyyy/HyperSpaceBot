using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using System.Text.RegularExpressions;

namespace HyperSpaceBot.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        [Command("roll")]
        public async Task roll()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 100);
            await Context.Channel.SendMessageAsync(randomNumber.ToString());
        }

        [Command("bet")]
        public async Task bet()
        {

        }

        [Command("Say")]
        [Alias("say")]
        [Summary("returns said sentence!")]
        public async Task Say(string message)
        {
            var channel = await Context.User.GetOrCreateDMChannelAsync();
            await channel.SendMessageAsync(message);
        }

        [Command("test")]
        public async Task help()
        {
            var channel = Context.Guild.GetTextChannel(404405844248231938);
            await channel.SendMessageAsync("asd");
          

        }
            
        

        [Command("casino")]
        public async Task casino(IGuildUser user)
        {
            var role = Context.Guild.Roles.FirstOrDefault(x => x.Name.ToString() == "bets");
            await (user as IGuildUser).AddRoleAsync(role);
            await Context.Channel.SendMessageAsync($"The role {role} was given to {user}");
        }

        [Command("coinflip")]

        public async Task coinflip()
        {
            Random rng = new Random();
            var result = rng.Next(0, 2) == 0 ? "Heads" : "Tails";
            await Context.Channel.SendMessageAsync($"You flipped {result}");
        }


        [Command("8")]
        [Summary("Gives a prediction")]
        public async Task EightBall([Remainder] string input)
        {
            if (input.ToLower().Contains('?'))
            {
                string[] predictionsTexts = new string[]
                           {
                 "It is certain",
                            "It is decidedly so",
                            "Without a doubt",
                            "Yes, definitely",
                            "You may rely on it",
                            "As I see it, yes",
                            "Most likely",
                            "Outlook good",
                            "Yes",
                            "Signs point to yes",
                            "Reply hazy try again",
                            "Ask again later",
                            "Better not tell you now",
                            "Cannot predict now",
                            "Concentrate and ask again",
                            "Don't count on it",
                            "My reply is no",
                            "My sources say no",
                            "Outlook not so good",
                            "Very doubtful"
                           };
                Random rand = new Random();
                int randomIndex = rand.Next(predictionsTexts.Length);
                string text = predictionsTexts[randomIndex];
                await ReplyAsync(Context.User.Mention + ", " + text);
            }
            else
            {
                await ReplyAsync(Context.User.Mention + ", " + "Maybe try asking a question.");
            }
        }

        [Command("userinfo"), Summary("Returns info about the current user, or the user parameter, if one passed.")]
        [Alias("user", "whois")]
        public async Task UserInfo([Summary("The (optional) user to get info for")] IUser user = null)
        {
            var userInfo = user ?? Context.Client.CurrentUser;
            await ReplyAsync($"``{userInfo.Username}#{userInfo.Discriminator}``");
        }

        //[Command("clear")]
        //[Summary("Clear an amount of messages in the channel")]
        //[RequireBotPermission(GuildPermission.ManageMessages)]
        //[RequireUserPermission(GuildPermission.ManageMessages)]
        //public async Task ClearMessage([Remainder] int x = 0)
        //{
        //    if (x <= 100)
        //    {
        //        var messagesToDelete = await Context.Channel.GetMessagesAsync(x + 1).Flatten();
        //        await Context.Channel.DeleteMessagesAsync(messagesToDelete);
        //        if (x == 1)
        //        {
        //            await Context.Channel.SendMessageAsync($"`{Context.User.Username} deleted 1 message`");

        //        }
        //        else
        //        {
        //            await Context.Channel.SendMessageAsync($"`{Context.User.Username} deleted {x} messages`");
        //        }
        //    }
        //    else
        //    {
        //        await Context.Channel.SendMessageAsync("you cannot delete more than 100 messages");
        //    }
        //}

        //[Command("role")]
        //public async Task GiveRole(IGuildUser user, string roleName)
        //{

        //    var role = Context.Guild.Roles.FirstOrDefault(x => x.Name.ToString() == roleName);
        //    if(role.ToString() == "Admin")
        //    {
        //        await (user as IGuildUser).AddRoleAsync(role);
        //        await Context.Channel.SendMessageAsync($"The role {role} was given to {user}");
        //    }
        //}

    }
}


   