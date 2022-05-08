using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyLibrary.BotDictionary;
using Discord;
using Discord.WebSocket;
using Networking.BotsClass.Discord;
using Discord.Commands;

namespace Networking
{
    internal class DiscordBot
    {
        static readonly string documentDirPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        static readonly string toketFilePath = @"\Skillbox\Universal Knowledge\Programm\Files\DiscordBotToken.txt";
        static string TelegramToken = System.IO.File.ReadAllText(documentDirPath + toketFilePath);

        private DiscordSocketClient discordClient;
        private CommandService command;



        internal void Bot()
        {
            DiscordClient client = new DiscordClient(TelegramToken);
            client.Connect();
            Console.ReadLine();

            Console.WriteLine("Discord Bot запустился :)))");
        }




        public async Task RunBot()
        {
            discordClient = new DiscordSocketClient();
            command = new CommandService();
            await discordClient.LoginAsync(TokenType.Bot, TelegramToken);
            await discordClient.StartAsync();
            discordClient.Log += Log;
            discordClient.MessageReceived += CommandHandler;
            discordClient.ButtonExecuted += ButtonClick;
            await Task.Delay(-1);
            Console.ReadLine();


        }

        public async Task ButtonClick(SocketMessageComponent arg)
        {
            await arg.DeferAsync();

            if(arg.Data.CustomId == "AllCommands")
            {
                await arg.Channel.SendMessageAsync($"Доступные команды:\n/Hi - поздороваться с ботом\n .........");
            }

        }



        /// <summary>
        /// Обработчик комманд
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private Task CommandHandler(SocketMessage arg)
        {
            throw new NotImplementedException();
        }

        private Task Log(LogMessage arg)
        {
            throw new NotImplementedException();
        }
    }
}
