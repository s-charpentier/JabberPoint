using System;
using System.Collections.Generic;
using System.Text;
using JabberPoint.Domain.Content.Behaviours;
using JabberPoint.Domain.Helpers;

namespace JabberPoint.Domain.Content
{
    public interface IContent
    {
        List<IContentBehaviour> Behaviours { get;}
        Bounds Bounds { get; }
    }
}
