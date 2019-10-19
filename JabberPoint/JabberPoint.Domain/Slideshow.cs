using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace JabberPoint.Domain
{
    public sealed class Slideshow : ISlideshow
    {
        public List<ISlideSection> Slides { get; private set; }
        public Dictionary<int, ISlideSection> Footers { get; set; } = new Dictionary<int, ISlideSection>();
        public ISlideSection GetFooter(int page)
        {
            return Footers.ContainsKey(page) ? Footers[page] : Footers[-1];
        }

        public Dictionary<string,string> MetaData { get { return _metaData; } }
        private  Dictionary<string, string> _metaData;

        public Slideshow()
        {
            this.Slides = new List<ISlideSection>();
            _metaData = new Dictionary<string, string>();
        }
        public string GetValueForKey(string key)
        {
            if (_metaData.ContainsKey(key))
                return _metaData[key];
            return "";
        }
        public string ReplaceTextWithMetaData(string text)
        {
            var output = text;
            foreach (var item in _metaData)
                output= Regex.Replace(output, $"/[{item.Key}/]", item.Value);
            return output;
        }
    }
}
