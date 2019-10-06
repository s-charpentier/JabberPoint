using JabberPoint.Domain.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberPoint.Business
{
    /// <summary>
    /// theme manager singleton. 
    /// manages the global retrieval and dissemination of theme data.
    /// </summary>
    public class ThemeManager
    {
        private Themes themes;
        private string currentTheme;
        private static ThemeManager _themeManager;
        private ThemeManager()
        {

        }
        /// <summary>
        /// static singleton creator function
        /// </summary>
        /// <returns>the theme manager</returns>
        public static ThemeManager GetSingleTon()
        {
            if (_themeManager == null)
                _themeManager = new ThemeManager();
            return _themeManager;
        }

        /// <summary>
        /// sets the currently used theme name
        /// </summary>
        /// <param name="name">the name of the theme</param>
        public void SetCurrentTheme(string name)
            => currentTheme = name;

        /// <summary>
        /// gets the style element for a specific level on a slide
        /// </summary>
        /// <param name="themeName">the name of the used theme</param>
        /// <param name="pageNr">the page of the slide</param>
        /// <param name="levelId">the level of the style</param>
        /// <returns>a style for a text content</returns>
        public Style GetStyleForTheme(string themeName, int pageNr, int levelId)
            => themes[themeName][pageNr][levelId];

        /// <summary>
        /// gets the style element for a specific level on a slide, as defined in the loaded theme
        /// </summary>
        /// <param name="pageNr">the page of the slide</param>
        /// <param name="levelId">the level of the style</param>
        /// <returns>a style for a text content</returns>
        public Style GetStyle(int pageNr,int levelId)
            => GetStyleForTheme(currentTheme,pageNr, levelId);

        /// <summary>
        /// gets the background image to use on the requested page for the requested theme
        /// </summary>
        /// <param name="themeName">the name of the used theme</param>
        /// <param name="pageNr">the page of the slide</param>
        /// <returns>the name of the background image to use</returns>
        public string GetBackgroundImage(string themeName, int pageNr)
            => themes[themeName][pageNr].BackgroundImage;

        /// <summary>
        /// gets the background image to use on the requested page for the loaded theme
        /// </summary>
        /// <param name="pageNr">the page of the slide</param>
        /// <returns>the name of the background image to use</returns>
        public string GetBackgroundImage(int pageNr)
            => GetBackgroundImage(currentTheme, pageNr);

        /// <summary>
        /// gets the background color to use on the requested page for the requested theme
        /// </summary>
        /// <param name="themeName">the name of the used theme</param>
        /// <param name="pageNr">the page of the slide</param>
        /// <returns>the hex code for the background color to use</returns>
        public string GetBackgroundColor(string themeName, int pageNr)
            => themes[themeName][pageNr].BackgroundColor;

        /// <summary>
        /// gets the background color to use on the requested page for the loaded theme
        /// </summary>
        /// <param name="pageNr">the page of the slide</param>
        /// <returns>the hex code for the background color to use</returns>
        public string GetBackgroundColor(int PageNr)
            => GetBackgroundColor(currentTheme, PageNr);


    }
}
