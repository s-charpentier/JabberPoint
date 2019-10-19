using System.Collections.ObjectModel;
using System.Windows;
using JabberPoint.Domain;

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
                    if (uiElement != null)
                        elements.Add(uiElement);
                    
                }
            }

            ContentElements = elements;
        }
        public SlideSectionViewModel(int currentIndex, ISlideshow slideshow)//Footer
        {
            var elements = new ObservableCollection<FrameworkElement>();
            wpfContentManager.Index = currentIndex;
            foreach (var content in slideshow.GetFooter(currentIndex).Contents)
            {
                foreach (var behaviour in content.Value.Behaviours)
                {
                    var uiElement = wpfContentManager.GetControl(behaviour);
                    if (uiElement != null)
                    {
                        elements.Add(uiElement);
                    }
                }
            }
            ContentElements = elements;
        }

    }
}