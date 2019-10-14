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
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace JabberPoint.View
{
   
    public class PresentationViewModel : ViewModel
    {
        private WindowController _controller;
        private ICommand _nextSlide;
        public ICommand NextSlide
            => _nextSlide ?? (_nextSlide = new RelayCommand(() => _controller?.NextSlide()));

        private ICommand _prevSlide;
        public ICommand PreviousSlide
            => _prevSlide ?? (_prevSlide = new RelayCommand(() => _controller?.PreviousSlide()));

        private ICommand _loadTheme;
        public ICommand LoadTheme
            => _loadTheme ?? (_loadTheme = new RelayCommand<string>(x => _controller?.LoadTheme(x)));

        private Brush _backGround = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#005566"));
        public Brush BackgroundColor
        {
            get { return _backGround; }
            set
            {
                _backGround = value;
                OnPropertyChanged();
            }
        }

        private string _image;
        public string BackgroundImage
        {
            get { return _image; }
            set
            {
                _image = value;
                OnPropertyChanged();
            }
        }

        private bool _imageUsed;

        public bool BackGroundUsed
        {
            get { return _imageUsed; }
            set
            {
                _imageUsed = value;
                OnPropertyChanged();
            }
        }

        

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
            var themes = Themes.GetSingleton();
            var used = !string.IsNullOrWhiteSpace(themes.GetBackgroundImage(currentIndex));
            BackGroundUsed = used;
            //BackgroundImage = new BitmapImage(new Uri(themes.GetBackgroundImage(currentIndex), UriKind.Relative)); 
            if (used)
            {
                
                BackgroundImage = AppDomain.CurrentDomain.BaseDirectory+"\\" + themes.GetBackgroundImage(currentIndex);
            }
          
            if(!BackGroundUsed)
                BackgroundColor=  new SolidColorBrush((Color)ColorConverter.ConvertFromString(themes.GetBackgroundColor(currentIndex)));

            CurrentSlideVM = new SlideSectionViewModel(slide,currentIndex);
            
        }




    }
   
    
}
