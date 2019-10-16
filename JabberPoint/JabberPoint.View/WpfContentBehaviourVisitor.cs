using JabberPoint.Domain.Content;
using JabberPoint.Domain.Content.Behaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JabberPoint.View
{
    public class WpfContentBehaviourVisitor : IContentBehaviourVisitor
    {
        public WpfContentBehaviourManager Manager { get; private set; }

        public WpfContentBehaviourVisitor(WpfContentBehaviourManager manager)
        {
            this.Manager = manager;
        }
        public void Visit(TextBehaviour behaviour)
        {
            this.Manager.Convert(behaviour);
        }
        public void Visit(MediaBehaviour behaviour)
        {
            this.Manager.Convert(behaviour);
        }
        public void Visit(LevelledBehaviour behaviour)
        {
            this.Manager.Convert(behaviour);
        }
        public void Visit(ListBehaviour behaviour)
        {
            this.Manager.Convert(behaviour);
        }
    }
}
