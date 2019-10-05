using JabberPoint.Domain.Content.Behaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JabberPoint.View.BehaviourDrawers
{
    class TextBehaviourDrawer : TextBehaviour, IBehaviourDrawer
    {
        TextBehaviour Behaviour { get; set; }
        public TextBehaviourDrawer(TextBehaviour behaviourToDraw)
        {
            this.Behaviour = behaviourToDraw;
        }

        public FrameworkElement Draw() {
            /*var levelBehaviour = textBehaviour.Parent.GetBehaviour<ILevelledBehaviour>();*/
            return new System.Windows.Controls.TextBlock()
            {
                Text = this.Behaviour.Text /*,
                    FontSize = levelBehaviour.FontSize,
                    FontFamily = new System.Windows.Media.FontFamily(levelBehaviour.Font),
                    FontStyle = levelBehaviour.FontStyle.HasFlag(JabberPoint.Domain.Helpers.FontStyle.Italic) ? FontStyles.Italic : FontStyles.Normal,
                    FontWeight = levelBehaviour.FontStyle.HasFlag(JabberPoint.Domain.Helpers.FontStyle.Italic) ? FontWeights.Bold : FontWeights.Normal,
                    Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom(levelBehaviour.FontColor)) */
            };
        }
    }
}
