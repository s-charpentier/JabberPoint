using System;
using System.Collections.Generic;
using System.Text;
using JabberPoint.Domain.Helpers;
namespace JabberPoint.Domain.Themes
{
    /// <summary>
    /// interface for style class
    /// </summary>
    public interface IStyle
    {
        /// <summary>
        /// determines the font or font-family used by this style
        /// </summary>
         string Font { get;  }
        /// <summary>
        /// determines the text color used by this style
        /// </summary>
         string FontColor { get; }
        /// <summary>
        /// determines whether the text is shown in italics or not
        /// </summary>
         FontStyle FontStyle { get; }
        /// <summary>
        /// determines whether the text is bold or not
        /// </summary>
        FontWeight FontWeight { get; }
        /// <summary>
        /// determines the size of the text
        /// </summary>
         int FontSize { get; }
        /// <summary>
        /// determines the position of the text (left, right, center)
        /// </summary>
         Alignment TextAlign { get; }
        /// <summary>
        /// determines whether the text is underlined or not
        /// </summary>
         TextDecoration TextDecoration { get; }

    }
    /// <summary>
    /// A style is a set of rules that determines how a single piece of content is shown in a slideshow
    /// </summary>
    public class Style : IStyle
    {
        public string Font { get;  set; }
        public string FontColor { get;  set; }
        public FontStyle FontStyle { get;  set; }
        public FontWeight FontWeight { get;  set; }
        public int FontSize { get;  set; }
        public Alignment TextAlign { get;  set; }
        public TextDecoration TextDecoration { get;  set; }

    }
}
