using JabberPoint.Domain.Content.Behaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JabberPoint.View.BehaviourDrawers
{
    public interface IBehaviourDrawer : IContentBehaviour
    {
        FrameworkElement Draw();
    }
}
