﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JabberPoint.Domain
{
    public interface ISlideshow
    {
        List<ISlideSection> Slides { get; }
        Dictionary<string,string> MetaData { get; }
    }
}
