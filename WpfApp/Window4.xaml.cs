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
using System.Windows.Shapes;

using Microsoft.VisualBasic;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        //static List<string> strings { get; set; }
        static ObservableCollection<string> strings { get; set; }

        public Window4()
        {
            InitializeVariables();
            InitializeComponent();
            listView1.ItemsSource = strings;

        }

        private static void InitializeVariables()
        {
            
            strings = new ObservableCollection<string>
            {
                "1",
                "2",
                "3"
            };

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string st = (int.Parse(strings.Last()) + 1).ToString();
            strings.Add(st);
        }
    }
}
