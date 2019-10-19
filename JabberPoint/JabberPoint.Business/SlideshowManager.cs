using JabberPoint.Data;
using JabberPoint.Domain;
using JabberPoint.Domain.Themes;
using JabberPoint.Domain.Content;
using JabberPoint.Domain.Content.Behaviours;
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
            => LoadSlides(inputUrl, GetWpfContent);

        public static void SetFooter(ISlideshow slideshow)
        {
            slideshow.Footers.Clear();
            var theme = Themes.GetSingleton();
            foreach (var footer in theme.GetFooterData())
            {
                ISlideSection footerSection = new SlideSection(slideshow);
                foreach(var footerdata in footer.Value)
                    footerSection.Contents.Add(footerSection.Contents.Count, new TextContentFactory(footerdata.Text, footerdata.Level).GetContent(slideshow));
                slideshow.Footers.Add(footer.Key,footerSection);
            }


        }

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
            return factory.GetContent(parent);
        }
       
    }
}
