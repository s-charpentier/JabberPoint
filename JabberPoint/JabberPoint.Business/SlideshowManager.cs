using JabberPoint.Data;
using JabberPoint.Domain;
using JabberPoint.Domain.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberPoint.Business
{
    public static class SlideshowManager
    {
        public static ISlideshow LoadDefaultXml()
            => LoadXmlFromFile("./slideshow.xml");
        public static ISlideshow LoadXmlFromFile(string inputUrl)
        {
            JabberPoint.Data.slideshow data;
            JabberPoint.Domain.Slideshow slideshow;

            XmlLoader loader = new XmlLoader(inputUrl);

            data = loader.RootObject;

            slideshow = new Slideshow();

            foreach (var dataslide in data.slides)
            {
                ISlide slide = new Slide();
                slideshow.Slides.Add(slide);

                foreach (var datacontent in dataslide.contents)
                {
                    var datacontentType = datacontent.type;

                    ContentFactory factory;

                    switch (datacontentType)
                    {
                        case "text":
                            factory = new TextContentFactory(datacontent.text.value, datacontent.level.value);
                            break;
                        case "image":
                        case "media":
                            factory = new ImageContentFactory(datacontent.reference.value);
                            break;
                        case "list":
                        default:
                            factory = null;
                            break;
                    }

                    IContent content = factory.GetContent();
                    slide.Contents.Add(content);
                }
            }

            return slideshow;
        }
    }
}
