using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json.Linq;

using Networking.BotsClass;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot.Extensions.Polling;

using MyLibrary.BotDictionary;
using System.Diagnostics;
using Newtonsoft.Json;
using File = System.IO.File;

namespace Networking
{
    internal class TelegramBots
    {
        private static TelegramBotClient? botClient;

        static readonly string documentDirPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        static readonly string toketFilePath = @"\Skillbox\Universal Knowledge\Programm\Files\TelegramBotToken.txt";
        static string TelegramToken = System.IO.File.ReadAllText(documentDirPath + toketFilePath);

        //static string TelegramToken = "TelegramToken";

        public static async void BotWithLibrary()
        {
            Forex forex = new Forex();

            botClient = new TelegramBotClient(TelegramToken);

            User me = await botClient.GetMeAsync();
            Console.Title = me.Username ?? "My awesome Bot";

            Program.user = me;

            //foreach (var up in update.Result)
            //{
            //    //var message = up.Message;
            //    //var mm = Handlers.BotOnMessageReceivedTextAsync(botClient, message);
            //    //var st = mm.IsFaulted ? "----" : mm.Result.Text;
            //    //Console.WriteLine($"{st}- {up.Message.Text}");

            //    //Console.WriteLine($"{up.Id}- {up.Type} - {up.Message.Text}");

            //    updates.Add(up);
            //}


            using var cts = new CancellationTokenSource();

            Console.WriteLine($"IsCancellationRequested - {cts.IsCancellationRequested}");

            // StartReceiver не блокирует вызывающий поток. Получение выполняется в ThreadPool.
            botClient.StartReceiving(updateHandler: Handlers.HandleUpdateAsync,
                               errorHandler: Handlers.HandleErrorAsync,
                               receiverOptions: new ReceiverOptions()
                               {
                                   AllowedUpdates = Array.Empty<UpdateType>()
                               },
                               cancellationToken: cts.Token);

            Console.WriteLine($"Начинаю прослушивать @{me.Username}");
            Debug.WriteLine($"Начинаю прослушивать @{me.Username}");
            Console.ReadLine();

            // Отправить запрос на отмену, чтобы остановить бота
            cts.Cancel();

            Console.ReadLine();
        }

        public static void PrimitiveBot()
        {
            #region Values

            string url, r;

            string directoryPath = PathToDirectory.FilesDir;

            BotAnswers botAnswers = new BotAnswers();

            Dictionary<string, string> responseTextDic = BotAnswers.Answers;

            #endregion

            WebClient wc = new WebClient() { Encoding = Encoding.UTF8 };

            int update_id = 0;                                              // для обозначения прочитанных сообщений
            string startUrl = $@"https://api.telegram.org/bot{TelegramToken}/";

            #region getMe

            //url = $"{startUrl}getMe";        //позволяет получить все сообщения отправленные боту
            //r = wc.DownloadString(url);
            //Console.WriteLine(r);
            //Console.Read();

            #endregion

            while (true)
            {
                url = startUrl + Methods.GetUpdates(update_id); ;        //позволяет получить все сообщения отправленные боту

                r = wc.DownloadString(url);

                Console.WriteLine(r);
                //Console.ReadLine();

                var msgs = JObject.Parse(r)["result"].ToArray();

                foreach (dynamic msg in msgs)
                {
                    update_id = Convert.ToInt32(msg.update_id) + 1;

                    if(msg.error != null)
                    {
                        Console.WriteLine(msg.error);
                        break;
                    }

                    if(msg.message == null)
                    {
                        Console.WriteLine($"{msg.update_id} message = null");
                        break;
                    }

                    if(msg.message.caption != null)
                    {
                        Console.WriteLine($"Описание: {msg.message.caption}");
                    }

                    if (msg.message.document != null)
                    {
                        Console.WriteLine($"Имя файла: {msg.message.document.file_name}");

                    }
                    else
                    {
                        string userMessage = msg.message.text;
                        string userId = msg.message.from.id;
                        string useFirstrName = msg.message.from.first_name;

                        //string text = $"{useFirstrName} {userId} {userMessage}";
                        //Console.WriteLine(text);

                        if (responseTextDic.ContainsKey(userMessage))
                        {
                            string message = responseTextDic[userMessage];
                            string responseText = $"{message}";

                            url = $"{startUrl}sendMessage?chat_id={userId}&text={responseText}";


                            wc.DownloadString(url);
                        }
                    }
                }

                Thread.Sleep(1000);         // 100
            }
        }
    }
}
