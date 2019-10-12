using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace JabberPoint.Data
{
    public class ThemeXmlLoader
    {
        private String InputUrl { get; set; }
        public theme RootObject { get; private set; }
        public ThemeXmlLoader(string inputUrl)
        {
            this.InputUrl = inputUrl;
            Read();
        }

        private void Read()
        {
            XmlSerializer mySerializer = new XmlSerializer(typeof(theme));
            this.RootObject = (theme)mySerializer.Deserialize(new FileStream(this.InputUrl, FileMode.Open));
        }
    }
}