using System;
using System.Collections.Generic;
using System.Text;
using JabberPoint.Domain.Content;

namespace JabberPoint.Domain
{
    public class SlideSection : ISlideSection
    {
        public SortedList<int, IContent> Contents { get; private set; }

       
        public SlideSection()
        {
            this.Contents = new SortedList<int, IContent>();
        }
    }
}
