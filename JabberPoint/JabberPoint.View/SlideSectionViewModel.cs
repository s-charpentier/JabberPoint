using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using JabberPoint.Domain;
using JabberPoint.Domain.Content.Behaviours;

namespace JabberPoint.View
{
    public class SlideSectionViewModel : ViewModel
    {
        private ObservableCollection<FrameworkElement> _contentElements;

        public ObservableCollection<FrameworkElement> ContentElements
        {
            get
            {
                return _contentElements;
            }
            set
            {
                _contentElements = value;
                OnPropertyChanged();
            }
        }

        public SlideSectionViewModel(ISlideSection slide, int index)//slide
        {
            var elements = new ObservableCollection<FrameworkElement>();

            foreach (var content in slide.Contents)
            {
                foreach (var behaviourDrawer in content.Value.Behaviours.OfType<IDrawableBehaviour<FrameworkElement>>())
                {
                    var uiElement = behaviourDrawer.Draw(index);
                    if (uiElement != null)
                        elements.Add(uiElement);
                    
                }
            }

            ContentElements = elements;
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