using System;
using System.Collections.Generic;
using System.Text;
using JabberPoint.Domain.Content.Behaviours;
using JabberPoint.Domain.Helpers;

namespace JabberPoint.Domain.Content
{
    public interface IContent : IMetadataProvider
    {
        List<IContentBehaviour> Behaviours { get;}
        T GetBehaviour<T>() where T : IContentBehaviour;
    }
}
