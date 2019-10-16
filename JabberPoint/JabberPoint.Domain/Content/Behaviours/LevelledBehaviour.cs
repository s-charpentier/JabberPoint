using System;
using System.Collections.Generic;
using System.Text;

namespace JabberPoint.Domain.Content.Behaviours
{
    public interface ILevelledBehaviour : IContentBehaviour
    {
        int Level { get; set; }
    }
    public class LevelledBehaviour : ILevelledBehaviour
    {
        public IContent Parent { get; set; }
        public int Level { get; set; }
        public void Accept(IContentBehaviourVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
