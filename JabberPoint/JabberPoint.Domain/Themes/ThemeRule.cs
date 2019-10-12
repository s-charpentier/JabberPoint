using System;
using System.Collections.Generic;
using System.Text;

namespace JabberPoint.Domain.Themes
{
    public interface IThemeRule
    {
        int LevelId { get; }
        IStyle Style { get; }
    }

    public class ThemeRule:IThemeRule
    {
        public int LevelId { get; set; }
        public IStyle Style { get; set; }
    }
}
