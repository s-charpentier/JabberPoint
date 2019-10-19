using System;
using System.Collections.Generic;
using System.Text;

namespace JabberPoint.Domain
{
    public interface ISlideshow:IMetadataProvider
    {
        List<ISlideSection> Slides { get; }
        Dictionary<int,ISlideSection> Footers { get; }
        ISlideSection GetFooter(int page);
    }
}
