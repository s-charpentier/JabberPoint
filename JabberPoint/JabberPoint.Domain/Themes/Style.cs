using System;
using System.Collections.Generic;
using System.Text;
using JabberPoint.Domain.Helpers;
namespace JabberPoint.Domain.Themes
{

    public interface IStyle
    {
         string Font { get;  }
         string FontColor { get; }
         FontStyle FontStyle { get; }
         FontWeight FontWeight { get; }
         int FontSize { get; }
         Alignment TextAlign { get; }
         TextDecoration TextDecoration { get; }

    }
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
