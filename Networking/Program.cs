using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml.Linq;

using System.Xml.Serialization;
using System.Data;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Networking
{
    class Program
    {
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


            //Thread taskPrimitiveBot = new Thread(TelegramBots.PrimitiveBot);
            //taskPrimitiveBot.Start();

            Thread taskBotWithLibrary = new Thread(TelegramBots.BotWithLibrary);
            taskBotWithLibrary.Start();

            //Thread taskDiscordBot = new Thread(DiscordBot.MainAsync);
            //taskDiscordBot.Start();

            DiscordBot discordBot = new DiscordBot();
            discordBot.Bot();

            Console.ReadLine();
        }

    }
}