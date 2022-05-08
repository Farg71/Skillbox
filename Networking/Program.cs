using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Data;
using System.Text;

using Telegram.Bot.Types;
using Networking.BotsClass;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using File = System.IO.File;

namespace Networking
{
    class Program
    {
        //static internal List<Message> messages = new List<Message>();
        //static internal List<User> users = new List<User>();
        //static internal List<Update> updates = new List<Update>();

        public static User user { get; set; }
        public static List<Update> updates { get; set; }

        static void Main(string[] args)
        {
            #region Задания
            /*
            Бот обладает следующим набором функций:
                                                                                                    Принимает сообщения и команды от пользователя.
            Сохраняет аудиосообщения, картинки и произвольные файлы.
            Позволяет пользователю просмотреть список загруженных файлов.
            Позволяет скачать выбранный файл.
                                                                                                    Команды можно делать разные, но среди них должна присутствовать команда /start.

            Вы можете сделать бота на любую тематику. Например, ваш бот может искать видео на YouTube,
            выводить курс криптовалют, отображать данные о погоде и так далее.

            Что оценивается
                                                                                                    Бот принимает текстовые сообщения.
                                                                                                    Бот реагирует на команду /start.
            Бот позволяет сохранять на диск изображения, аудио- и другие файлы.
            С помощью произвольной команды можно просмотреть список сохранённых файлов и скачать любой из них.
            */
            #endregion

            user = new User();
            updates = new List<Update>();

            if (File.Exists(PathToDirectory.FilesDir + "telegramBotLog.json")) JsonFileRead();

            //Thread taskPrimitiveBot = new Thread(TelegramBots.PrimitiveBot);
            //taskPrimitiveBot.Start();

            Thread taskBotWithLibrary = new Thread(TelegramBots.BotWithLibrary);
            taskBotWithLibrary.Start();

            //Thread taskDiscordBot = new Thread(DiscordBot.MainAsync);
            //taskDiscordBot.Start();

            //DiscordBot discordBot = new DiscordBot();
            //discordBot.Bot();

            Console.ReadLine();
            //Console.WriteLine("Сохранить!");

            JsonFileWrite();

            //Console.ReadLine();
        }

        private static void JsonFileWrite()
        {
            string jsonUpdates = JsonConvert.SerializeObject(updates);
            string jsonUser = JsonConvert.SerializeObject(user);

            JObject main = new JObject();

            JArray array = JArray.Parse(jsonUpdates);
            JObject us = JObject.Parse(jsonUser);

            main["user"] = us;
            main["updates"] = array;

            //Console.WriteLine(main.ToString());

            File.WriteAllText(PathToDirectory.FilesDir + "telegramBotLog.json", main.ToString());
        }

        private static void JsonFileRead()
        {
            string json = File.ReadAllText(PathToDirectory.FilesDir + "telegramBotLog.json");

            string jsonUser = JObject.Parse(json)["user"].ToString();
            user = JsonConvert.DeserializeObject<User>(jsonUser);

            string jsonUpdates = JObject.Parse(json)["updates"].ToString();
            updates = JsonConvert.DeserializeObject<List<Update>>(jsonUpdates);

            //Console.WriteLine(user.Username);
            //foreach (var up in updates)
            //{
            //    Console.WriteLine(up.Message.Text);
            //}
        }
    }
}