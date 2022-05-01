using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyLibrary.BotDictionary;
using Discord;
using Discord.WebSocket;
using Networking.BotsClass.Discord;

namespace Networking
{
    internal class DiscordBot
    {
        static readonly string documentDirPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        static readonly string toketFilePath = @"\Skillbox\Universal Knowledge\Programm\Files\DiscordBotToken.txt";
        static string TelegramToken = System.IO.File.ReadAllText(documentDirPath + toketFilePath);

        private DiscordSocketClient discordClient;




        internal void Bot()
        {
            DiscordClient client = new DiscordClient(TelegramToken);
            client.Connect();
            Console.ReadLine();

            Console.WriteLine("Discord Bot запустился :)))");
        }
    }
}
