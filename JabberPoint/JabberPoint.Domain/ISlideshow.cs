﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JabberPoint.Domain
{
    public interface ISlideshow
    {
        List<Slide> Slides { get; }
    }
}
