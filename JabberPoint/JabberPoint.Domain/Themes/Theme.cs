﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace JabberPoint.Domain.Themes
{
    public interface ITheme
    {
        string Name { get; }
        Dictionary<int, PageTheme> PageThemes{ get; }
        PageTheme this[int page] { get; }
    }
    /// <summary>
    /// 
    /// The Theme class is the main enty poitn for all theme rules belonging to a specific theme.
    /// </summary>
    public class Theme
    {

        /// <summary>
        /// the name of the theme
        /// </summary>
        public string Name { get;  set; }
        /// <summary>
        /// the collection of page themes, the key being the pages for which a different theme exists.
        /// </summary>
        public Dictionary<int, IPageTheme> PageThemes { get;  set; } = new Dictionary<int, IPageTheme>();

        /// <summary>
        /// Gets the themerules for a specific page, or, if the page cannot be found, gets the 0 location item.
        /// </summary>
        /// <param name="page">the number of the page for which to retrieve the themes</param>
        /// <returns>the themerules for the pagenumber provided, or the default themerules</returns>
        public IPageTheme this[int page] => PageThemes.FirstOrDefault(x => x.Key  == page).Value?? PageThemes[0];

        

    }
   
}
