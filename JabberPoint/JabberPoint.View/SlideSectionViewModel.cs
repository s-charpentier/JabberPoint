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

        private WpfContentBehaviourManager wpfContentManager = new WpfContentBehaviourManager();

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
            wpfContentManager.Index = index;

            foreach (var content in slide.Contents)
            {
                foreach (var behaviour in content.Value.Behaviours)
                {
                    var uiElement = wpfContentManager.GetControl(behaviour);
//                    var uiElement = behaviour.Draw(index);
                    if (uiElement != null)
                        elements.Add(uiElement);
                    
                }
            }

            ContentElements = elements;
        }
        public SlideSectionViewModel(int currentIndex, ISlideshow slideshow)//Footer
        {
            wpfContentManager.Index = currentIndex;
            foreach (var content in slideshow.Footer.Contents)
            {
                foreach (var behaviour in content.Value.Behaviours)
                {
                    var uiElement = wpfContentManager.GetControl(behaviour);
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