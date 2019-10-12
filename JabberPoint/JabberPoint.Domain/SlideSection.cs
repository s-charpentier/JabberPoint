using System;
using System.Collections.Generic;
using System.Text;
using JabberPoint.Domain.Content;

namespace JabberPoint.Domain
{
    public class SlideSection : ISlideSection
    {
        public SortedList<int, IContent> Contents { get; private set; }
        private IMetadataProvider _parent;
       
        public SlideSection(IMetadataProvider parent)
        {
            this.Contents = new SortedList<int, IContent>();
        }

        public string GetValueForKey(string key)
        {
            return _parent.GetValueForKey(key);
        }
    }
}
