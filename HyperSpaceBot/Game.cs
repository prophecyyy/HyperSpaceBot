using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace HyperSpaceBot
{
    class Game
    {
        private List<KeyValuePair<string, int>> list = new List<KeyValuePair<string, int>>();
        public Game()
        {

        }
      
        public void addList(String nome, int valor)
        {
            list.Insert(0, new KeyValuePair<string, int>(nome, valor));
        }

        
    }
}
