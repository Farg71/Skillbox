using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

using WPF.BotClass;

namespace WPF
{
    /// <summary>
    /// Логика взаимодействия для TokenInput.xaml
    /// </summary>
    public partial class TokenInput : Window
    {
        MainWindow mainWindow;

        public TokenInput()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void token_MouseEnter(object sender, MouseEventArgs e)
        {
            //MessageBox.Show($"MouseEnter {token.Text}");
            if (this.token.Text == "Token")
                this.token.Text = String.Empty;
        }

        private void token_MouseLeave(object sender, MouseEventArgs e)
        {
            if(this.token.Text == "")
                this.token.Text = "Token";
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            Metodes.TelegramToken = this.token.Text.ToString();

            Metodes.BotStartReceiving(mainWindow);

            Metodes.status = Brushes.Green;

            Close();
        }
    }
}
