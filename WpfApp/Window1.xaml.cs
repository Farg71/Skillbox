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

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void TxtYes_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show($"Я в этом не сомневался");
        }

        private void TxtNo_MouseEnter(object sender, MouseEventArgs e)
        {
            // запоминание текущей плзиции кнопки ДА и кнопки НЕТ
            var posLeftTxtYes = Canvas.GetLeft(txtYes);
            var posLeftTxtNo = Canvas.GetTop(txtNo);

            Canvas.SetLeft(txtYes, posLeftTxtNo);
            Canvas.SetTop(txtNo, posLeftTxtYes);

            //SystemSound.Hand.Play();

        }
    }
}
