using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;
using JabberPoint.Domain.Content;
using JabberPoint.Domain.Content.Behaviours;
using JabberPoint.Domain.Themes;

namespace JabberPoint.Domain.View.Wpf.Content.Behaviours
{

    public class WpfTextBehaviour : TextBehaviour<FrameworkElement>//, IDrawableBehaviour<FrameworkElement>
    {
        
        
        public override FrameworkElement Draw(int pageNr)
        {
            var themeManager = JabberPoint.Domain.Themes.Themes.GetSingleton();
            var levelBehaviour = this.Parent.GetBehaviour<ILevelledBehaviour>();
            var style = themeManager.GetStyle(pageNr, levelBehaviour.Level);
            return new System.Windows.Controls.TextBlock()
            {
                Text = Slideshow.ReplaceTextWithMetaData(Text).Replace("[PageNr]",pageNr.ToString()) ,
                    FontSize = style.FontSize,
                    FontFamily = new System.Windows.Media.FontFamily(style.Font),
                    FontStyle = style.FontStyle.HasFlag(JabberPoint.Domain.Helpers.FontStyle.Italic) ? FontStyles.Italic : FontStyles.Normal,
                    FontWeight = style.FontWeight.HasFlag(JabberPoint.Domain.Helpers.FontWeight.Bold) ? FontWeights.Bold : FontWeights.Normal,
                    Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom(style.FontColor)) 
            };
        }
    }
}
