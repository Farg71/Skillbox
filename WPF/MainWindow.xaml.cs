using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telegram.Bot;

using WPF.BotClass;
using Telegram.Bot.Types;
using System.Diagnostics;
using System.Threading;
using Telegram.Bot.Types.Enums;
using System.Collections.Specialized;

using File = System.IO.File;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // partial - неоходимо для разбивки класса на несколько файлов?

        //static readonly string documentDirPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        //static readonly string toketFilePath = @"\Skillbox\Universal Knowledge\Programm\Files\TelegramBotToken.txt";
        //static string TelegramToken = System.IO.File.ReadAllText(documentDirPath + toketFilePath);


        /// <summary>
        /// Главное окно бота
        /// </summary>
        public MainWindow()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            InitializeComponent();

            TokenInputWindowOpen();

            TelegramStatus();

            Metodes.DownloadCollections();

            usersList.ItemsSource = Metodes.BotUsersCollection; //установка источника данных
        }

        /// <summary>
        /// Открытие окна для ввода токена
        /// </summary>
        internal void TokenInputWindowOpen()
        {
            TokenInput tokenInput = new TokenInput();

            tokenInput.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            tokenInput.Show();
        }

        /// <summary>
        /// Определяем заголовок окна по имени бота, заполняем прямоугольник цветом
        /// </summary>
        private void TelegramStatus()
        {
            this.Title = Metodes.Me.Username ?? "My awesome Bot";

            if (Metodes.Cts != null)
            {
                rectStatus.Fill = !Metodes.Cts.IsCancellationRequested ? Brushes.Green : Brushes.Red;
            }
            else
            {
                rectStatus.Fill = Brushes.Red;
            }

            Metodes.status = rectStatus.Fill;
        }

        /// <summary>
        /// Происходит перед закрытием окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainWindow_Closed(object sender, EventArgs e)
        {
            // Отправить запрос на отмену, чтобы остановить бота
            if (Metodes.Cts != null)
            {
                Metodes.Cts.Cancel();
                //MessageBox.Show($"Заканчиваю прослушивать @{me.Username}");
                //Debug.WriteLine($"Заканчиваю прослушивать @{me.Username}");
            }
        }

        /// <summary>
        /// Кнопка Send
        /// </summary>
        private void btnSendMsg_Click(object sender, RoutedEventArgs e)
        {
            if (Metodes.status == Brushes.Green)
            {
                _ = Metodes.SendText(Convert.ToInt64(chatId.Text), txtBxSendMsg.Text);

                MessageBox.Show(chatId.Text);

                txtBxSendMsg.Text = String.Empty;
            }
        }

        /// <summary>
        /// Меню File/Telegram Bot Close
        /// </summary>
        private void bot_Close_Click(object sender, RoutedEventArgs e)
        {
            Metodes.Cts.Cancel();

            //MessageBox.Show($"Заканчиваю прослушивать @{me.Username}");
            Debug.WriteLine($"Заканчиваю прослушивать @{Metodes.Me.Username}");

            TelegramStatus();
        }

        /// <summary>
        /// Меню File/Telegram Bot Open
        /// </summary>
        private void bot_Open_Click(object sender, RoutedEventArgs e)
        {
            TokenInputWindowOpen();
        }

        /// <summary>
        /// Происходит при выведении окна на передний план
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainWindow_Activated(object sender, EventArgs e)
        {
            rectStatus.Fill = Metodes.status;
        }

        /// <summary>
        /// Перед самим закрытием
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Metodes.JsonFileWriteAsync(Metodes.BotUsersCollection, "BotUsers");
        }

        private void usersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var user = Metodes.BotUsersCollection.Where(x => x.ChatId == Convert.ToInt64(chatId.Text)).First().Messages.ToList();

            //var u = user.Select((l) => $"{l.Item2} - {l.Item3}").Last();
            //var u = user.Select((l) => $"{l.Item2.TimeOfDay} - {l.Item3}");
            var u = user.Select((l) => $"{l.Item2} - {l.Item3}");
            //var us = user.OrderByDescending(x => x.Item2);

            //var u = us.Select((l) => $"{l.Item2.TimeOfDay} - {l.Item3}");

            concreteUsersChat.ItemsSource = u;

        }
    }
}
