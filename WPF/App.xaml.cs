using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // override - увидеть можно точки входа и задать явно
        // например, выполнить метод до запуска основного приложения

        protected override void OnStartup(StartupEventArgs e)
        {
            //base.OnStartup(e);
            //MessageBox.Show("Hello");
        }
    }
}
