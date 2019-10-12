using JabberPoint.Data;
using JabberPoint.Domain;
using JabberPoint.Domain.Themes;
using JabberPoint.Domain.Content;
using JabberPoint.Domain.Content.Behaviours;
using JabberPoint.Domain.View.Wpf.Content.Behaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberPoint.Business
{
    public static class SlideshowManager
    {
        public static void ThemeLoader(string inputUrl= "./themes.xml")
        {
            var theme = Themes.GetSingleton();
            
            //load from xml here
        }

        public static ISlideshow LoadDefaultXml()
            => LoadXmlFromFile("./slideshow.xml");

        public static ISlideshow LoadXmlFromFile(string inputUrl)
            => LoadSlides(inputUrl, GetWpfContent);   
        

        private static ISlideshow LoadSlides(string inputUrl,Func<slideshowSlideContent, ISlideSection, IContent> factoryLoader)
        {
            JabberPoint.Data.slideshow data;
            JabberPoint.Domain.Slideshow slideshow;

            SlideshowXmlLoader loader = new SlideshowXmlLoader(inputUrl);

            data = loader.RootObject;

            slideshow = new Slideshow();

            foreach (var dataslide in data.slides)
            {
                ISlideSection slide = new SlideSection(slideshow);
                slideshow.Slides.Add(slide);

                foreach (var datacontent in dataslide.contents)
                {
                    slide.Contents.Add(slide.Contents.Count, factoryLoader(datacontent,slide));
                }
            }
            slideshow.MetaData["[PageCount]"] = slideshow.Slides.Count.ToString();
            return slideshow;
        }

        private static IContent GetWpfContent(slideshowSlideContent contentData, ISlideSection parent)
        {
            IContentFactory factory;
            switch (contentData.type)
            {
                case "text":
                    factory = new TextContentFactory<WpfTextBehaviour>(contentData.text.value, contentData.level.value);
                    break;
                case "image":
                case "media":
                    factory = new ImageContentFactory<WpfMediaBehaviour>(contentData.reference.value);
                    break;
                case "list":
                default:
                    factory = null;
                    break;
            }
            return factory.GetContent(parent);
        }
       
    }
}
