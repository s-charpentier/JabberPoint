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

using JabberPoint;

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
            CreateImage();
            CreateLabel();
            CreateLabel();
            CreateImage();
            CreateLabel();
            CreateImage();
        }

        private void CreateLabel()
        {

            Label label = new Label();

            label.Content = "Hello World";
            label.Foreground = new SolidColorBrush(Colors.White);
            label.Background = new SolidColorBrush(Colors.Black);

            SlideshowArea.Children.Add(label);
        }

        private void CreateImage()
        {

            Image img = new Image();

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("https://cdn.pixabay.com/photo/2013/07/12/17/47/test-pattern-152459__340.png");
            bitmap.EndInit();
            img.Source = bitmap;

            img.Height = 100;

            SlideshowArea.Children.Add(img);
        }

        //
    }
}
