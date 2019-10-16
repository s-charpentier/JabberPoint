using JabberPoint.Domain;
using JabberPoint.Domain.Content;
using JabberPoint.Domain.Content.Behaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace JabberPoint.View
{
    public class WpfContentBehaviourManager
    {
        public FrameworkElement Control { get; private set; }
        public int Index { get; set; }
        public WpfContentBehaviourVisitor Visitor { get; private set;  }

        public WpfContentBehaviourManager()
        {
            this.Visitor = new WpfContentBehaviourVisitor(this);
        }

        public FrameworkElement GetControl(IContentBehaviour behaviour) {
            behaviour.Accept(this.Visitor);
            return this.Control;
        }
        public void Convert(TextBehaviour behaviour)
        {
            int pageNr = this.Index;
            var themeManager = JabberPoint.Domain.Themes.Themes.GetSingleton();
            var levelBehaviour = behaviour.Parent.GetBehaviour<ILevelledBehaviour>();
            var style = themeManager.GetStyle(pageNr, levelBehaviour.Level);
            var control = new System.Windows.Controls.TextBlock()
            {
                Text = Slideshow.ReplaceTextWithMetaData(behaviour.Text).Replace("[PageNr]", pageNr.ToString()),
                FontSize = style.FontSize,
                FontFamily = new System.Windows.Media.FontFamily(style.Font),
                FontStyle = style.FontStyle.HasFlag(JabberPoint.Domain.Helpers.FontStyle.Italic) ? FontStyles.Italic : FontStyles.Normal,
                FontWeight = style.FontWeight.HasFlag(JabberPoint.Domain.Helpers.FontWeight.Bold) ? FontWeights.Bold : FontWeights.Normal,
                Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom(style.FontColor))
            };
            this.Control = control;
        }
        public void Convert(MediaBehaviour behaviour)
        {
            var bitmap = new BitmapImage(new Uri(behaviour.Reference, UriKind.Relative));
            var control = new System.Windows.Controls.Image() { Source = bitmap, Height = bitmap.Height };
            this.Control = control;
        }
        public void Convert(ListBehaviour behaviour)
        {
        }
        public void Convert(LevelledBehaviour behaviour)
        {
        }
    }
}
