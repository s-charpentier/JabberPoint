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
using JabberPoint.View.BehaviourDrawers;

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

            ISlide currentSlide = this.Slideshow.Slides[0];
            this.CurrentSlideVM = new CurrentSlideViewModel(currentSlide,CurrentIndex);
            OnPropertyChanged("CurrentSlideVM");
        }

        public void SetCurrentSlide(int slideNumber) {

            if (slideNumber >= this.Slideshow.Slides.Count ||
                slideNumber < 0) {
                return;
            }
            CurrentIndex = slideNumber;
            ISlide currentSlide = this.Slideshow.Slides[this.CurrentIndex];
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

        private IBehaviourDrawer GetBehaviourDrawer(IContentBehaviour behaviour)
        {
            IBehaviourDrawer drawer;

            switch (behaviour.GetType().Name)
            {
                case nameof(TextBehaviour):
                    drawer = new TextBehaviourDrawer(behaviour as TextBehaviour);
                    break;
                default:
                    drawer = null;
                    break;
            }
            return drawer;
        }
    }
    public class FooterViewModel : ViewModel
    {

    }
    public class CurrentSlideViewModel : ViewModel
    {
        ISlide slide { get; set; }
        public ObservableCollection<FrameworkElement> ContentElements { get; set; }

        public CurrentSlideViewModel(ISlide slide,int index)
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
