using System;
using System.Collections.Generic;
using System.Text;

namespace JabberPoint.Domain
{
    public sealed class Slideshow : ISlideshow
    {
        public List<ISlide> Slides { get; private set; }
        public Slideshow()
        {
            this.Slides = new List<ISlide>();
        }
    }
}
