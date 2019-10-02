using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace JabberPoint.Data
{
    public class XmlLoader
    {
        private String InputUrl { get; set; }
        public slideshow RootObject { get; private set; }
        public XmlLoader(string inputUrl)
        {
            this.InputUrl = inputUrl;
        }

        private void Read() {
            XmlSerializer mySerializer = new XmlSerializer(typeof(slideshow));
            this.RootObject = (slideshow)mySerializer.Deserialize(new FileStream(this.InputUrl, FileMode.Open));
        }
    }
}
