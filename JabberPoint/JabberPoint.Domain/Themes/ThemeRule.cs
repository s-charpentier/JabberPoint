using System;
using System.Collections.Generic;
using System.Text;

namespace JabberPoint.Domain.Themes
{
    /// <summary>
    /// interface for the ThemeRule class
    /// </summary>
    public interface IThemeRule
    {
        /// <summary>
        /// id that identifies a style. Multiple levels can identify the same style.
        /// </summary>
        int LevelId { get; }
        /// <summary>
        /// the style that matches the level
        /// </summary>
        IStyle Style { get; }
    }

    /// <summary>
    /// A themerule applies a style to a content of a specific level
    /// </summary>
    public class ThemeRule:IThemeRule
    {
        public int LevelId { get; set; }
        public IStyle Style { get; set; }
    }
}
