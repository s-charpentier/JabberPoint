using System;
using System.Collections.Generic;
using System.Text;
using JabberPoint.Domain.Content.Behaviours;

namespace JabberPoint.Domain.Content
{
    public interface IContent
    {
        IContentProperty MyBehaviour { get;}
    }
}
