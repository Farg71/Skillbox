using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using File = System.IO.File;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Media;

namespace WPF.BotClass
{
    internal class Metodes
    {
        internal static MainWindow mainWindow { get; set; }

        internal static string TelegramToken { get; set; }

        internal static TelegramBotClient TelegramBot { get; set; }

        internal static Update Update { get; set; }

        internal static Message Message { get; set; }

        internal static CancellationTokenSource Cts { get; set; }

        internal static User Me = new User();

        internal static Brush status { get; set; }

        internal static ObservableCollection<BotUser> BotUsersCollection { get; set; }


        /// <summary>
        /// Начало прослушивание ботом Телеграмканала
        /// </summary>
        /// <param name="w"></param>
        internal static void BotStartReceiving(MainWindow w)
        {
            mainWindow = w;

            TelegramBot = new TelegramBotClient(TelegramToken);

            Cts = new CancellationTokenSource();

            BotUsersCollection.CollectionChanged += BotUsersCollection_CollectionChanged;

            Me = TelegramBot.GetMeAsync().Result;

            var updates = TelegramBot.GetUpdatesAsync();

            //Update = updates.Result.LastOrDefault();

            // StartReceiver не блокирует вызывающий поток. Получение выполняется в ThreadPool.
            TelegramBot.StartReceiving(updateHandler: HandleUpdateAsync,
                                errorHandler: HandleErrorAsync,
                                receiverOptions: new ReceiverOptions()
                                {
                                    AllowedUpdates = Array.Empty<UpdateType>()
                                },
                                cancellationToken: Cts.Token);

            //MessageBox.Show($"Начинаю прослушивать @{me.Username}");

            Debug.WriteLine($"Начинаю прослушивать @{Me.Username}");
        }

        /// <summary>
        /// Обработчик события: Изменение BotUsersCollection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void BotUsersCollection_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            MessageBox.Show($"BotUsersCollection_CollectionChanged");
        }

        /// <summary>
        /// Асинхронная обработка обновления
        /// </summary>
        /// <param name="botClient"></param>
        /// <param name="update">Класс Update: https://core.telegram.org/bots/api#update</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            Update = update;

            TelegramBot = (TelegramBotClient)botClient;

            var handler = update.Type switch
            {
                UpdateType.Message => BotOnMessageReceived(),
                UpdateType.EditedMessage => BotOnMessageReceived(),
                _ => UnknownUpdateHandlerAsync()
            };

            try
            {
                await handler;
            }
            catch (Exception exception)
            {
                await HandleErrorAsync(botClient, exception, cancellationToken);
            }
        }

        /// <summary>
        /// Асинхронная обработка ошибок
        /// </summary>
        /// <param name="botClient">клиент</param>
        /// <param name="exception">исключение</param>
        /// <param name="cancellationToken">токен отмены</param>
        /// <returns></returns>
        private static Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Ассинхронная обработка всех UpdateType, кроме Message и EditedMessage
        /// </summary>
        /// <returns></returns>
        private static Task UnknownUpdateHandlerAsync()
        {
            MessageBox.Show($"Unknown update type: {Update.Type}");
            return Task.CompletedTask;
        }

        /// <summary>
        /// Получение сообщения
        /// </summary>
        /// <param name="botClient"></param>
        /// <param name="update"></param>
        /// <returns></returns>
        public static async Task BotOnMessageReceived()
        {
            if (Update != null)
            {
                AddUserToCollection();

                var message = Update.Message!;

                if (message.Type != MessageType.Text) return;

                var action = message.Text!.Split(' ')[0] switch
                {
                    "/help" => Help(message.Chat.Id),
                    "/start" => Start(message.Chat.Id),
                    _ => TextOutput(message.Chat.Id)
                };

                Message sentMessage = await action;
            }
        }

        /// <summary>
        /// Добавление и пользователей и сообщений в коллекцию
        /// </summary>
        private static void AddUserToCollection()
        {
            var message = Update.Message;

            var usersList = BotUsersCollection.ToList();

            if (!usersList.Exists(x=> x.ChatId == message.Chat.Id))
            {
                BotUser botUser = new BotUser(message.Chat.Id, message.Chat.FirstName, message.Chat.LastName,
                    message.Chat.Username, message.From.LanguageCode, message.From.IsBot);

                botUser.AddMessage(true, message.Date, message.Text);

                BotUsersCollection.Add(botUser);
            }
            else
            {
                usersList.Find(x => x.ChatId == message.Chat.Id).AddMessage(true, message.Date, message.Text);
            }
        }

        /// <summary>
        /// сейчас ничего не вывожу. Можно подключить анализ текста и вывод по словарю ответов
        /// </summary>
        /// <param name="chatId">Номер чата</param>
        /// <returns></returns>
        internal static Task<Message> TextOutput(long chatId)
        {
            return Task.FromResult(Message);
        }

        /// <summary>
        /// ответ бота на комманду /start
        /// </summary>
        /// <param name="chatId"></param>
        /// <returns></returns>
        private static async Task<Message> Start(long chatId)
        {
            const string usage = "Использование:\n" +
                                    "/start    - Описание комманд\n" +
                                    "/help     - Получение помощи\n";

            return await SendText(chatId, usage);
        }

        /// <summary>
        /// ответ бота на комманду /help
        /// </summary>
        /// <param name="chatId"></param>
        /// <returns></returns>
        private static async Task<Message> Help(long chatId)
        {
            string text = "Здесь всё просто. Помогать не буду! :)))";

            return await SendText(chatId, text);
        }

        /// <summary>
        /// отправка ботом сообщения и запись его в коллекцию
        /// </summary>
        /// <param name="chatId"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        internal static async Task<Message> SendText(long chatId, string text)
        {
            if (BotUsersCollection.ToList().Exists(x => x.ChatId == chatId))
                BotUsersCollection.ToList().Find(x => x.ChatId == chatId).AddMessage(false, DateTime.Now, text);

            MessageBox.Show(text);

            return await TelegramBot.SendTextMessageAsync(chatId: chatId,
                                                        text: text,
                                                        replyMarkup: new ReplyKeyboardRemove());
        }

        /// <summary>
        /// сохранение архива коллекции
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="fileName"></param>
        internal static void JsonFileWriteAsync(object collection, string fileName)
        {
            string json = JsonConvert.SerializeObject(collection, Formatting.Indented);

            using (StreamWriter sw = File.CreateText(PathToDirectory.FilesDir + fileName + ".json"))
            {
                sw.WriteAsync(json);
            }
        }

        /// <summary>
        /// Чтение архива коллекции BotUsers
        /// </summary>
        internal static void JsonFileReadAsync()
        {
            using(StreamReader sr = File.OpenText(PathToDirectory.FilesDir + "BotUsers" + ".json"))
            {
                BotUsersCollection = JsonConvert.DeserializeObject<ObservableCollection<BotUser>>(sr.ReadToEndAsync().Result);
            }
        }

        /// <summary>
        /// Инициализация и загрузка архива коллукции BotUsers
        /// </summary>
        internal static void DownloadCollections()
        {
            BotUsersCollection = new ObservableCollection<BotUser>();

            if (File.Exists(PathToDirectory.FilesDir + "BotUsers.json")) JsonFileReadAsync();
        }

    }
}
