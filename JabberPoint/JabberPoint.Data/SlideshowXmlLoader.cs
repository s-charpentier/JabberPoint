using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace JabberPoint.Data
{
    public class SlideshowXmlLoader
    {
        private String InputUrl { get; set; }
        public slideshow RootObject { get; private set; }
        public SlideshowXmlLoader(string inputUrl)
        {
            this.InputUrl = inputUrl;
            Read();
        }

        private void Read() {
            XmlSerializer mySerializer = new XmlSerializer(typeof(slideshow));
            this.RootObject = (slideshow)mySerializer.Deserialize(new FileStream(this.InputUrl, FileMode.Open));
        }
    }
}
