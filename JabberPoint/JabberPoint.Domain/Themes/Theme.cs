using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace JabberPoint.Domain.Themes
{
    /// <summary>
    /// 
    /// The Theme class is the main enty poitn for all theme rules belonging to a specific theme.
    /// </summary>
    public class Theme
    {

        /// <summary>
        /// the name of the theme
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// the collection of page themes, the key being the pages for which a different theme exists.
        /// </summary>
        public Dictionary<int, PageTheme> PageThemes { get; private set; } = new Dictionary<int, PageTheme>();

        /// <summary>
        /// Gets the themerules for a specific page, or, if the page cannot be found, gets the 0 location item.
        /// </summary>
        /// <param name="page">the number of the page for which to retrieve the themes</param>
        /// <returns>the themerules for the pagenumber provided, or the default themerules</returns>
        public PageTheme this[int page] => PageThemes.FirstOrDefault(x => x.Key  == page).Value?? PageThemes[0];

        public SlideSection Footer { get; set; }
    }
    /// <summary>
    /// The theme definition that can be grouped per individual page.
    /// </summary>
    public class PageTheme
    {
        public string BackgroundColor { get; private set; }
        public string BackgroundImage { get; private set; }
        public List<ThemeRule> ThemeRules { get; private set; } = new List<ThemeRule>();

        

        public Style this[int level] => ThemeRules.First(x => x.LevelId == level).Style;
    }
}
