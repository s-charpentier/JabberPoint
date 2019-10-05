using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberPoint.Domain.Content.Behaviours
{
    public abstract class ContentBehaviourDrawer
    {
        public Func<Object, Object> UiConverter { get; set; }

        public Object Draw()
        {
            return UiConverter?.Invoke(this);
        }
    }
}
