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
            _parent = parent;
        }

        public string GetValueForKey(string key)
        {
            //if each slidesection piece had a metadata object, an inbetween check is needed here.
            return _parent.GetValueForKey(key);
        }
        public string ReplaceTextWithMetaData(string text)
        {
           return _parent.ReplaceTextWithMetaData(text);
        }
    }
}
