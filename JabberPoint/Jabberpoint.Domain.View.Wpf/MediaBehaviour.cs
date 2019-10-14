
using System;
using System.Collections.Generic;
using System.Text;
using JabberPoint.Domain.Content;
using JabberPoint.Domain.Content.Behaviours;
using System.Windows;
using System.Windows.Media.Imaging;

namespace JabberPoint.Domain.View.Wpf.Content.Behaviours
{

    public class WpfMediaBehaviour :MediaBehaviour<FrameworkElement>
    {
        public override FrameworkElement Draw(int pageNr)
        {
            var bitmap = new BitmapImage(new Uri(Reference, UriKind.Relative));
            var control = new System.Windows.Controls.Image() { Source = bitmap, Height= bitmap.Height };
            
            return control;
        }
    }
}
