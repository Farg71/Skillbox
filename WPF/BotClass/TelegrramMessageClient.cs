using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

using Newtonsoft.Json;
using File = System.IO.File;
using System.Threading;

namespace WPF.BotClass
{
    class TelegramMessageClient
    {
        private MainWindow window;

        private TelegramBotClient botClient;

        public ObservableCollection<MessageLog> BotMessageLog { get; set; }

        public Dictionary<long, ObservableCollection<MessageLog>> BotMessagesLogsDictionary { get; set; }

        public TelegramMessageClient(MainWindow window, string messagesLogsFilesPath, string telegramToken)
        {
            this.BotMessagesLogsDictionary = new Dictionary<long, ObservableCollection<MessageLog>>();

            if (File.Exists(messagesLogsFilesPath)) ReadMessagesDictionary(messagesLogsFilesPath);

            this.window = window;

            botClient = new TelegramBotClient(telegramToken);

            User user = botClient.GetMeAsync().Result;

            using var cts = new CancellationTokenSource();

            botClient.OnApiResponseReceived += BotClient_OnApiResponseReceived;

            cts.Cancel();
        }

        private ValueTask BotClient_OnApiResponseReceived(ITelegramBotClient botClient, ApiResponseEventArgs args, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void ReadMessagesDictionary(string messagesLogsFilesPath)
        {
            string txt = File.ReadAllTextAsync(messagesLogsFilesPath).Result;
            BotMessagesLogsDictionary = JsonConvert.DeserializeObject<Dictionary<long, ObservableCollection<MessageLog>>>(txt);
        }

        public void WriteMessagesDictionary(string messagesLogsFilesPath)
        {
            File.WriteAllTextAsync(messagesLogsFilesPath, JsonConvert.SerializeObject(BotMessagesLogsDictionary));
        }


    }
}
