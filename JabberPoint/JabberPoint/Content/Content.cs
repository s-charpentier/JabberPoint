using System;
using System.Collections.Generic;
using System.Text;
using JabberPoint.Domain.Content.Behaviours;

namespace JabberPoint.Domain.Content
{
    public abstract class Content : IContent
    {
        public IContentProperty MyBehaviour { get; protected set; }
    }
}
