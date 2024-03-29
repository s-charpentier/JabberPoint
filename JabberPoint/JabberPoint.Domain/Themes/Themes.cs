﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JabberPoint.Domain.Themes
{
    /// <summary>
    /// theme manager singleton. 
    /// manages the global retrieval and dissemination of theme data.
    /// </summary>
    public class Themes
    {
        /// <summary>
        /// List of all loaded ThemeCollections
        /// </summary>
        private List<ThemeCollection> _internalList { get; set; } = new List<ThemeCollection>();
        /// <summary>
        /// replaces the current list of ThemeCollections
        /// </summary>
        /// <param name="themes"></param>
        public void SetList(IEnumerable<ThemeCollection> themes)
        {
            foreach(var theme in themes)
                if(_internalList.All(x => x.Name != theme.Name)) _internalList.Add(theme);
           
        }

        /// <summary>
        /// the currently selected theme
        /// </summary>
        private string currentTheme;
        /// <summary>
        /// singleton reference
        /// </summary>
        private static Themes _themeManager;
        /// <summary>
        /// private constructor for singleton pattern
        /// </summary>
        private Themes()
        {

        }
        /// <summary>
        /// static singleton creator function
        /// </summary>
        /// <returns>the theme manager</returns>
        public static Themes GetSingleton()
        {
            if (_themeManager == null)
                _themeManager = new Themes();
            return _themeManager;
        }
        
        /// <summary>
        /// gets the theme denoted by a specific name
        /// </summary>
        /// <param name="name">the theme name</param>
        /// <returns></returns>
        public ThemeCollection this[string name]=>_internalList.First(x=>x.Name == name);


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
        public IStyle GetStyleForTheme(string themeName, int pageNr, int levelId)
            =>this[themeName][pageNr][levelId];

        /// <summary>
        /// gets the style element for a specific level on a slide, as defined in the loaded theme
        /// </summary>
        /// <param name="pageNr">the page of the slide</param>
        /// <param name="levelId">the level of the style</param>
        /// <returns>a style for a text content</returns>
        public IStyle GetStyle(int pageNr,int levelId)
            => GetStyleForTheme(currentTheme,pageNr, levelId);

        /// <summary>
        /// gets the background image to use on the requested page for the requested theme
        /// </summary>
        /// <param name="themeName">the name of the used theme</param>
        /// <param name="pageNr">the page of the slide</param>
        /// <returns>the name of the background image to use</returns>
        public string GetBackgroundImage(string themeName, int pageNr)
            => this[themeName][pageNr].BackgroundImage;

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
            => this[themeName][pageNr].BackgroundColor;

        /// <summary>
        /// gets the background color to use on the requested page for the loaded theme
        /// </summary>
        /// <param name="pageNr">the page of the slide</param>
        /// <returns>the hex code for the background color to use</returns>
        public string GetBackgroundColor(int PageNr)
            => GetBackgroundColor(currentTheme, PageNr);

        public Dictionary<int,List<IFooterData>> GetFooterData()
            =>this[currentTheme].PageThemes.ToDictionary(x => x.Key, x => x.Value.FooterData);
    }
}
