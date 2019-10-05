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
        CurrentSlideViewModel CurrentSlideVM { get; set; }
        public PresentationViewModel()
        {
            this.Slideshow = SlideshowManager.LoadDefaultXml();
            this.CurrentIndex = 0;

            foreach (var slide in this.Slideshow.Slides)
            {
                foreach (var content in slide.Contents)
                {
                    foreach (var behaviour in content.Behaviours.OfType<ContentBehaviourDrawer>())
                    {
                        BehaviourUiFactory factory = null;
                        if (behaviour as ITextBehaviour != null)
                        {
                            factory = new TextBehaviourUiFactory();
                        }

                        if (factory != null)
                        {
                            factory.DefineAction(behaviour);
                        }
                    }
                }
            }

            ISlide currentSlide = this.Slideshow.Slides[0];
            this.CurrentSlideVM = new CurrentSlideViewModel(currentSlide);
            OnPropertyChanged("CurrentSlideVM");
        }
    }
    public class CurrentSlideViewModel : ViewModel
    {
        ISlide slide { get; set; }
        ObservableCollection<FrameworkElement> ContentElements { get; set; }

        public CurrentSlideViewModel(ISlide slide)
        {
            ContentElements = new ObservableCollection<FrameworkElement>();
            this.slide = slide;

            foreach (var content in this.slide.Contents)
            {
                foreach (var behaviourDrawer in content.Behaviours.OfType<ContentBehaviourDrawer>())
                {
                    var uiElement = (FrameworkElement)behaviourDrawer.Draw();
                    if (uiElement != null) {
                        ContentElements.Add(uiElement);
                    }
                }
            }
            OnPropertyChanged("ContentElements");
        }
    }
}
