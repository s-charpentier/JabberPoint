using System;
using System.Collections.Generic;
using System.Text;

namespace JabberPoint.Domain.Helpers
{
    [Flags]
    public enum FontStyle
    {
        Normal=0,
        Bold = 1<<1,
        Italic = 1<<2
    }
}
