using JabberPoint.Business;
using JabberPoint.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace JabberPoint.View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var main = new MainWindow();
            main.DataContext = new PresentationViewModel();
            main.Show();
        }
    }
}
