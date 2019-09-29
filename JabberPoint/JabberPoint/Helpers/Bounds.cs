using System;
using System.Collections.Generic;
using System.Text;

namespace JabberPoint.Domain.Helpers
{
    public struct Bounds
    {
        public Bounds(int x,int y,int height,int width)
        {
            X = x;
            Y = y;
            Height=height;
            Width = width;
        }
        readonly int X, Y, Height, Width;
    }
}
