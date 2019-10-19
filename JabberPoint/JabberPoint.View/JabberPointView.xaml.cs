using System;
using System.Collections.Generic;
using System.IO;
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

using JabberPoint;

namespace JabberPoint.View
{
    /// <summary>
    /// Interaction logic for JabberPointView.xaml
    /// </summary>
    public partial class JabberPointView : Window
    {
        public JabberPointView()
        {
            InitializeComponent();
            foreach (FileInfo file in new DirectoryInfo("./").EnumerateFiles().Where(x => x.Name.StartsWith("theme")))
            {
                var menuItem = new MenuItem()
                {
                    Header = file.Name, Name= file.Name.Split('.')[0]

                };
                menuItem.SetBinding(MenuItem.CommandProperty, new Binding("LoadTheme"));
                menuItem.CommandParameter = file.Name;
                
                themes.Items.Add(menuItem);
            }
                
        }

        
    }
}
