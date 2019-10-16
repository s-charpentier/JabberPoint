using JabberPoint.Domain.Content.Behaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberPoint.Domain.Content
{
    public interface IContentBehaviourVisitor
    {
        void Visit(TextBehaviour behaviour);
        void Visit(MediaBehaviour behaviour);
        void Visit(LevelledBehaviour behaviour);
        void Visit(ListBehaviour behaviour);
    }
}
