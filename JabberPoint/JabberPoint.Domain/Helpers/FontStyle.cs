﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JabberPoint.Domain.Helpers
{
    [Flags]
    public enum FontStyle
    {
        Normal=0,
        Italic = 1<<1
    }
}
