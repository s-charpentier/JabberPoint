using JabberPoint.Domain.Content.Behaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberPoint.View
{
    public abstract class BehaviourUiFactory
    {
        public abstract void DefineAction(ContentBehaviourDrawer drawer);
    }

    public class TextBehaviourUiFactory : BehaviourUiFactory
    {
        public override void DefineAction(ContentBehaviourDrawer drawer) 
        {
            drawer.UiConverter = (inTextBehaviour) =>
            {
                var textBehaviour = (ITextBehaviour)inTextBehaviour;
                /*var levelBehaviour = textBehaviour.Parent.GetBehaviour<ILevelledBehaviour>();*/
                return new System.Windows.Controls.TextBlock()
                {
                    Text = textBehaviour.Text /*,
                    FontSize = levelBehaviour.FontSize,
                    FontFamily = new System.Windows.Media.FontFamily(levelBehaviour.Font),
                    FontStyle = levelBehaviour.FontStyle.HasFlag(JabberPoint.Domain.Helpers.FontStyle.Italic) ? FontStyles.Italic : FontStyles.Normal,
                    FontWeight = levelBehaviour.FontStyle.HasFlag(JabberPoint.Domain.Helpers.FontStyle.Italic) ? FontWeights.Bold : FontWeights.Normal,
                    Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom(levelBehaviour.FontColor)) */
                };
            };
        }
    }
}
