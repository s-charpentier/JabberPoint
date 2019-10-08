using System;
using System.Collections.Generic;
using System.Text;

namespace JabberPoint.Domain
{
    public interface ISlideshow
    {
        List<ISlide> Slides { get; }
        Dictionary<string,string> MetaData { get; }
    }
}
