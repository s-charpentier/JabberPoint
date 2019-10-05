using System;
using System.Collections.Generic;
using System.Text;
using JabberPoint.Domain.Helpers;
namespace JabberPoint.Domain.Themes
{
    public class Style
    {
        public string Font { get; private set; }
        public string FontColor { get; private set; }
        public FontStyle FontStyle { get; private set; }
        public FontWeight FontWeight { get; private set; }
        public int FontSize { get; private set; }
        public Alignment TextAlign { get; private set; }
        public TextDecoration TextDecoration { get; private set; }

    }
}
