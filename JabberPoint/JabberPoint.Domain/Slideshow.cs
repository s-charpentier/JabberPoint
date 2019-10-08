using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace JabberPoint.Domain
{
    public sealed class Slideshow : ISlideshow
    {
        public List<ISlide> Slides { get; private set; }
        public Dictionary<string,string> MetaData { get { return _metaData; } }
        private static Dictionary<string, string> _metaData;
        public Slideshow()
        {
            this.Slides = new List<ISlide>();
            _metaData = new Dictionary<string, string>();
        }

        public static string ReplaceTextWithMetaData(string text)
        {
            var output = text;
            foreach (var item in _metaData)
                output= Regex.Replace(output, $"/[{item.Key}/]", item.Value);
            return output;
        }
    }
}
