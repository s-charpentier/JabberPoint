using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using JabberPoint.Domain.Content.Behaviours;

namespace JabberPoint.Domain.Content
{
    public class Content : IContent
    {
        public List<IContentBehaviour> MyBehaviours { get; private set; }

        public Content (params IContentBehaviour[] behaviours) : this(behaviours) { }
        public Content (IEnumerable<IContentBehaviour> behaviours) 
        {
            MyBehaviours = behaviours.ToList();
        }
    }
}
