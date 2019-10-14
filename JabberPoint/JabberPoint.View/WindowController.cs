using JabberPoint.Business;
using JabberPoint.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JabberPoint.Domain.Themes;

namespace JabberPoint.View
{
    public class WindowController
    {
        public delegate void UpdateSlideHandler(ISlideSection slide, int currentIndex);

        public delegate void UpdateThemeHandler(ISlideSection footer, string background, string image);
        ISlideshow Slideshow { get; set; }
        int CurrentIndex { get; set; }
        public event UpdateSlideHandler UpdateSlide;
        public event UpdateThemeHandler UpdateTheme;
        public WindowController()
        {
            this.Slideshow = SlideshowManager.LoadDefaultXml();
            ThemeManager.ThemeLoader();

            this.CurrentIndex = 0;
        }

        public void LoadTheme(string name)
        {
            ThemeManager.ThemeLoader(name);

            
            
            
            SetCurrentSlide(CurrentIndex);
        }
        public void SetCurrentSlide(int slideNumber)
        {

            if (slideNumber >= this.Slideshow.Slides.Count ||
                slideNumber < 0)
            {
                return;
            }
            CurrentIndex = slideNumber;
            ISlideSection currentSlide = this.Slideshow.Slides[this.CurrentIndex];
            UpdateSlide?.Invoke(currentSlide, CurrentIndex);

        }
        public void FirstSlide()
            => SetCurrentSlide(0);
        public void NextSlide()
            =>SetCurrentSlide(this.CurrentIndex + 1);
        

        public void PreviousSlide()
            => SetCurrentSlide(this.CurrentIndex - 1);
        
    }
}
