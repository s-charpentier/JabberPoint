using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using JabberPoint.Domain.Content;
using JabberPoint.Domain.Content.Behaviours;

namespace JabberPoint.Domain.View.Wpf.Content.Behaviours
{

    public class WpfTextBehaviour : ITextBehaviour, IDrawableBehaviour<FrameworkElement>
    {
        public IContent Parent { get; set; }
        public string Text { get; set; }
        
        public FrameworkElement Draw(int pageNr)
        {
            var themeManager = ThemeManager.GetSingleton();
            var levelBehaviour = textBehaviour.Parent.GetBehaviour<ILevelledBehaviour>();
            return new System.Windows.Controls.TextBlock()
            {
                Text = this.Text /*,
                    FontSize = levelBehaviour.FontSize,
                    FontFamily = new System.Windows.Media.FontFamily(levelBehaviour.Font),
                    FontStyle = levelBehaviour.FontStyle.HasFlag(JabberPoint.Domain.Helpers.FontStyle.Italic) ? FontStyles.Italic : FontStyles.Normal,
                    FontWeight = levelBehaviour.FontStyle.HasFlag(JabberPoint.Domain.Helpers.FontStyle.Italic) ? FontWeights.Bold : FontWeights.Normal,
                    Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom(levelBehaviour.FontColor)) */
            };
        }
    }
}
