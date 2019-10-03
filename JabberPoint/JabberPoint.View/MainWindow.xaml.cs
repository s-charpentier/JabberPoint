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

namespace JabberPoint.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CreateLabel();
            CreateLabel();
            CreateLabel();
        }

        private void CreateLabel()

        {

            Label dynamicLabel = new Label();

            dynamicLabel.Name = "McLabel";

            dynamicLabel.Content = "Hello World";

            dynamicLabel.Width = 240;

            dynamicLabel.Height = 30;

            dynamicLabel.Foreground = new SolidColorBrush(Colors.White);

            dynamicLabel.Background = new SolidColorBrush(Colors.Black);

            SlideshowArea.Children.Add(dynamicLabel);

        }
    }
}
