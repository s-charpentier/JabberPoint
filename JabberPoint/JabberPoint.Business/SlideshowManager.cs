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
                    slide.Contents.Add(GetWpfContent(datacontent));
                }
            }

            return slideshow;
        }

        private static IContent GetWpfContent(slideshowSlideContent contentData)
        {
            IContentFactory factory;
            switch (contentData.type)
            {
                case "text":
                    factory = new WpfTextContentFactory(contentData.text.value, contentData.level.value);
                    break;
                case "image":
                case "media":
                    factory = new WpfImageContentFactory(contentData.reference.value);
                    break;
                case "list":
                default:
                    factory = null;
                    break;
            }
            return factory.GetContent();
        }
        private static IContent GetContent(slideshowSlideContent contentData)
        {
            IContentFactory factory;
            switch (contentData.type)
            {
                case "text":
                    factory = new TextContentFactory(contentData.text.value, contentData.level.value);
                    break;
                case "image":
                case "media":
                    factory = new ImageContentFactory(contentData.reference.value);
                    break;
                case "list":
                default:
                    factory = null;
                    break;
            }
            return factory.GetContent();
        }
    }
}
