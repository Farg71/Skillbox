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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // partial - неоходимо для разбивки класса на несколько файлов?
        public MainWindow()
        {
            InitializeComponent();
        }

        int count = 0;
        private void btnClick(object sender, RoutedEventArgs e)
        {
            Title = $"Кнопка нажата {++count}";
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show(
                    "Текст пустой",
                    this.Title,
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Information
                    );
            }
            else
            {
                MessageBox.Show(
                    $"Привет, {textBox1.Text}",
                    this.Title,
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning
                    );

            }
        }

        //private void Rect_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    rect.Fill = Brushes.Blue;
        //}

        //private void Rect_MouseUp(object sender, MouseButtonEventArgs e)
        //{
        //    rect.Fill = Brushes.Yellow;
        //}

        //private void Rect_MouseEnter(object sender, MouseEventArgs e)
        //{
        //    rect.Fill = Brushes.Black;
        //}

        //private void Rect_MouseLeave(object sender, MouseEventArgs e)
        //{
        //    rect.Fill = Brushes.Aqua;
        //}

        private void button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btn_OpenWin1(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.Show();
        }

        private void btn_OpenWin2(object sender, RoutedEventArgs e)
        {
            Window2 window2 = new Window2();
            window2.Show();

        }
    }
}
