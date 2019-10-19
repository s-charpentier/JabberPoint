using System;
using System.Collections.Generic;
using System.Text;

namespace JabberPoint.Domain
{
    public interface ISlideshow:IMetadataProvider
    {
        Dictionary<string, string> MetaData { get; }
        List<ISlideSection> Slides { get; }
        Dictionary<int,ISlideSection> Footers { get; }
        ISlideSection GetFooter(int page);
    }
}
