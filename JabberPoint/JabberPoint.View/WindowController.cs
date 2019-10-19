using JabberPoint.Business;
using JabberPoint.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JabberPoint.Domain.Themes;
using Microsoft.Win32;

namespace JabberPoint.View
{
    public class WindowController
    {
        public delegate void UpdateSlideHandler(ISlideSection slide, int currentIndex);

        public delegate void SetValueHandler(string value);

        public delegate void UpdateThemeHandler(ISlideSection footer, string background, string image);
        ISlideshow Slideshow { get; set; }
        int CurrentIndex { get; set; }
        private string folder;
        public event UpdateSlideHandler UpdateSlide;
        public event UpdateSlideHandler UpdateFooter;
        public WindowController()
        {
            
            ThemeManager.ThemeLoader();

            this.Slideshow = SlideshowManager.LoadDefaultXml();
            SlideshowManager.SetFooter(Slideshow);
            this.CurrentIndex = 0;
        }

        public void SetFilePath()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                DefaultExt = "*.xml",
                Filter = "Slideshow (.xml)|*.xml"
            };
            if (openFileDialog.ShowDialog() == true)
            {
               
                this.Slideshow = SlideshowManager.LoadXmlFromFile(openFileDialog.FileName);
                this.Slideshow.MetaData.Add("RootFolder", openFileDialog.FileName.Substring(0, openFileDialog.FileName.LastIndexOf('\\')));
                
                SlideshowManager.SetFooter(Slideshow);
                this.CurrentIndex = 0;
                SetCurrentSlide(CurrentIndex);
            }
               
        }
        

        public void LoadTheme(string name)
        {

            ThemeManager.ThemeLoader(name);

            SlideshowManager.SetFooter(Slideshow);
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
            ISlideSection currentFooter = this.Slideshow.GetFooter(this.CurrentIndex);
            UpdateSlide?.Invoke(currentSlide, CurrentIndex);
            UpdateFooter?.Invoke(currentFooter, CurrentIndex);

        }
        public void FirstSlide()
            => SetCurrentSlide(0);
        public void NextSlide()
            =>SetCurrentSlide(this.CurrentIndex + 1);
        

        public void PreviousSlide()
            => SetCurrentSlide(this.CurrentIndex - 1);

        public void Exit()
            => Environment.Exit(0);

    }
}
