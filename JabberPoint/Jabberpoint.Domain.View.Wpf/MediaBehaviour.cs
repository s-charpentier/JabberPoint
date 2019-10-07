
using System;
using System.Collections.Generic;
using System.Text;
using JabberPoint.Domain.Content;
using JabberPoint.Domain.Content.Behaviours;
using System.Windows;
using System.Windows.Media.Imaging;

namespace JabberPoint.Domain.View.Wpf.Content.Behaviours
{

    public class WpfMediaBehaviour : IMediaBehaviour<FrameworkElement>
    {
        public IContent Parent { get; set; }
        public string Reference { get; set; }
        public string IsPlaying { get; private set; }
        public FrameworkElement Draw()
        {
            return new System.Windows.Controls.Image() { Source = new BitmapImage(new Uri( Reference)) };
        }
    }
}