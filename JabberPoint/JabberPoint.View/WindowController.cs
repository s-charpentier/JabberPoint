using JabberPoint.Business;
using JabberPoint.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberPoint.View
{
    public class WindowController
    {
        public delegate void UpdateSlideHandler(ISlideSection slide, int currentIndex);
        ISlideshow Slideshow { get; set; }
        int CurrentIndex { get; set; }
        public event UpdateSlideHandler UpdateSlide;
        public WindowController()
        {
            this.Slideshow = SlideshowManager.LoadDefaultXml();
            ThemeManager.ThemeLoader();

            this.CurrentIndex = 0;
            
           // ISlideSection currentSlide = this.Slideshow.Slides[0];
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
            //this.CurrentSlideVM = new CurrentSlideViewModel(currentSlide, CurrentIndex);
            //OnPropertyChanged("CurrentSlideVM");

        }
        public void FirstSlide()
            => SetCurrentSlide(0);
        public void NextSlide()
            =>SetCurrentSlide(this.CurrentIndex + 1);
        

        public void PreviousSlide()
            => SetCurrentSlide(this.CurrentIndex - 1);
        
    }
}
