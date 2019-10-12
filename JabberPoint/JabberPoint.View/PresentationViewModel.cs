using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows;
using JabberPoint.Domain;
using JabberPoint.Business;
using JabberPoint.Domain.Content.Behaviours;
using JabberPoint.Domain.Themes;
using System.Windows.Data;

namespace JabberPoint.View
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName=null)
            =>PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));        
    }
    public class PresentationViewModel : ViewModel
    {
        ISlideshow Slideshow { get; set; }
        int CurrentIndex { get; set; }
        public CurrentSlideViewModel CurrentSlideVM { get; set; }
        public FooterViewModel CurrentThemeFooterVM { get; set; }
        

        public PresentationViewModel()
        {
            this.Slideshow = SlideshowManager.LoadDefaultXml();
            SlideshowManager.ThemeLoader();

            this.CurrentIndex = 0;

            //foreach (var slide in this.Slideshow.Slides)
            //{
            //    foreach (var content in slide.Contents)
            //    {
            //        for (int i = 0; i < content.Behaviours.Count; i++)
            //        {
            //            var drawer = GetBehaviourDrawer(content.Behaviours[i]);
            //            if (drawer != null) {
            //                content.Behaviours[i] = drawer;
            //            }
            //        }
            //    }
            //}

            ISlideSection currentSlide = this.Slideshow.Slides[0];
            this.CurrentSlideVM = new CurrentSlideViewModel(currentSlide,CurrentIndex);
            OnPropertyChanged("CurrentSlideVM");
        }

        public void SetCurrentSlide(int slideNumber) {

            if (slideNumber >= this.Slideshow.Slides.Count ||
                slideNumber < 0) {
                return;
            }
            CurrentIndex = slideNumber;
            ISlideSection currentSlide = this.Slideshow.Slides[this.CurrentIndex];
            this.CurrentSlideVM = new CurrentSlideViewModel(currentSlide,CurrentIndex);
            OnPropertyChanged("CurrentSlideVM");
        }

        public void NextSlide()
        {
            SetCurrentSlide(this.CurrentIndex + 1);
        }

        public void PreviousSlide()
        {
            SetCurrentSlide(this.CurrentIndex - 1);
        }
       
    }
    public class FooterViewModel : ViewModel
    {
        public ObservableCollection<FrameworkElement> ContentElements { get; set; }

        public FooterViewModel(int currentIndex)
        {
            ContentElements = new ObservableCollection<FrameworkElement>();
       

            foreach (var content in Themes.GetSingleton().GetFooter().Contents)
            {
                foreach (var behaviourDrawer in content.Value.Behaviours.OfType<IDrawableBehaviour<FrameworkElement>>())
                {
                    var uiElement = behaviourDrawer.Draw(currentIndex);
                    if (uiElement != null)
                    {
                        ContentElements.Add(uiElement);
                    }
                }
            }
            OnPropertyChanged("ContentElements");
        }
    }
    public class CurrentSlideViewModel : ViewModel
    {
        public string BackgroundColor { get; set; } = "#005566";
        public string BackgroundImage { get; set; }
        public bool BackGroundUsed => string.IsNullOrWhiteSpace(BackgroundImage);
        ISlideSection slide { get; set; }
        public ObservableCollection<FrameworkElement> ContentElements { get; set; }

        public CurrentSlideViewModel(ISlideSection slide,int index)
        {
            ContentElements = new ObservableCollection<FrameworkElement>();
            this.slide = slide;

            foreach (var content in this.slide.Contents)
            {
                foreach (var behaviourDrawer in content.Value.Behaviours.OfType<IDrawableBehaviour<FrameworkElement>>())
                {
                    var uiElement = behaviourDrawer.Draw(index);
                    if (uiElement != null) {
                        ContentElements.Add(uiElement);
                    }
                }
            }
            OnPropertyChanged("ContentElements");
        }
    }
}
