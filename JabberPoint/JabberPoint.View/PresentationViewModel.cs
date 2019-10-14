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
using System.Windows.Input;

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
        public string BackgroundColor { get; set; } = "#005566";
        public string BackgroundImage { get; set; }
        public bool BackGroundUsed => string.IsNullOrWhiteSpace(BackgroundImage);

        private WindowController _controller;
        private ICommand _nextSlide;
        public ICommand NextSlide
            => _nextSlide ?? (_nextSlide = new RelayCommand(() => _controller?.NextSlide())); 
        
        private ICommand _prevSlide;
        public ICommand PreviousSlide
            => _prevSlide ?? (_prevSlide = new RelayCommand(() => _controller?.PreviousSlide())); 
        
        private SlideSectionViewModel _currentSlideViewModel;
        public SlideSectionViewModel CurrentSlideVM
        {
            get
            {
                return _currentSlideViewModel;
            }
            set
            {
                _currentSlideViewModel = value;
                OnPropertyChanged();
            }
        }
        public SlideSectionViewModel CurrentThemeFooterVM { get; set; }

        public PresentationViewModel(WindowController controller)
        {
            _controller = controller;
            _controller.UpdateSlide += UpdateSlide;


            _controller?.FirstSlide();

        }
        public void UpdateSlide(ISlideSection slide, int currentIndex)
        {
            CurrentSlideVM = new SlideSectionViewModel(slide,currentIndex);
            
        }




    }
   
    public class SlideSectionViewModel : ViewModel
    {
        
        ISlideSection slide { get; set; }
        public ObservableCollection<FrameworkElement> ContentElements { get; set; }

        public SlideSectionViewModel(ISlideSection slide,int index)//slide
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
        public SlideSectionViewModel(int currentIndex, ISlideshow slideshow)//Footer
        {
            foreach (var content in slideshow.Footer.Contents)
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
            OnPropertyChanged("ContentElement");
        }

    }
}
