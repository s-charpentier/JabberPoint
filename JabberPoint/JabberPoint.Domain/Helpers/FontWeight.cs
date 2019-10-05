using System;
using System.Collections.Generic;
using System.Text;

namespace JabberPoint.Domain.Helpers
{
    [Flags]
    public enum FontWeight
    {
        Normal = 0,
        Bold = 1 << 1
    }
}
