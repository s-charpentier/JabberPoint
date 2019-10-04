using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JabberPoint.Domain.Content;
using JabberPoint.Domain.Content.Behaviours;
using System.Windows;
using System.Windows.Media;


namespace JabberPoint.View.InterfaceExtensions
{
    public static class ContentDrawExtensions
    {
        public static JabberPoint.Domain.Themes.Theme AllThemes = new Domain.Themes.Theme();
        public static FrameworkElement Draw(this IContent slide)
        {
            throw new NotImplementedException();
        }

        public static FrameworkElement Draw(this ITextBehaviour text)
        {
            var level= AllThemes[text.Parent.Behaviours.OfType<ILevelledBehaviour>().First().Level];
            return new System.Windows.Controls.TextBlock()
            {
                Text = text.Text,
                FontSize = level.FontSize,
                FontFamily = new System.Windows.Media.FontFamily(level.Font),
                FontStyle = level.FontStyle.HasFlag(JabberPoint.Domain.Helpers.FontStyle.Italic) ? FontStyles.Italic : FontStyles.Normal,
                FontWeight = level.FontStyle.HasFlag(JabberPoint.Domain.Helpers.FontStyle.Italic) ? FontWeights.Bold : FontWeights.Normal,
                Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom(level.FontColour))
            };
        }
    }
}
