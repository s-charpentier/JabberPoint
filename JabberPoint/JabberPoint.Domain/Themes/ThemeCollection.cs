using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace JabberPoint.Domain.Themes
{
    /// <summary>
    /// interface for ThemeCollection class
    /// </summary>
    public interface IThemeCollection
    {
        /// <summary>
        /// the name of the ThemeCollection
        /// </summary>
        string Name { get; }
        /// <summary>
        /// determines which page uses which theme
        /// </summary>
        Dictionary<int, Theme> PageThemes{ get; }
        /// <summary>
        /// square bracket operator overload for retrieving the theme of a particular page
        /// </summary>
        /// <param name="page">the page number for which a theme should be returned</param>
        /// <returns></returns>
        Theme this[int page] { get; }
    }
    /// <summary>
    /// The ThemeCollection class is the main enty poitn for all theme rules belonging to a specific theme.
    /// A slideshow can use different themes per page, so a themecollection is loaded, containing specific themes per page.
    /// </summary>
    public class ThemeCollection
    {

        /// <summary>
        /// the name of the theme
        /// </summary>
        public string Name { get;  set; }
        /// <summary>
        /// the collection of page themes, the key being the pages for which a different theme exists.
        /// </summary>
        public Dictionary<int, ITheme> PageThemes { get; set; } = new Dictionary<int, ITheme>();

        /// <summary>
        /// Gets the themerules for a specific page, or, if the page cannot be found, gets the 0 location item.
        /// </summary>
        /// <param name="page">the number of the page for which to retrieve the themes</param>
        /// <returns>the themerules for the pagenumber provided, or the default themerules</returns>
        public ITheme this[int page] => PageThemes.FirstOrDefault(x => x.Key  == page).Value?? PageThemes[-1];

        

    }
   
}
