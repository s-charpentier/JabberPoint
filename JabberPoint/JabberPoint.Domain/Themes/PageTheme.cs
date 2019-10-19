using System.Collections.Generic;
using System.Linq;

namespace JabberPoint.Domain.Themes
{
    public interface ITheme
    {
        IStyle this[int level] { get; }

        string BackgroundColor { get; }
        string BackgroundImage { get; }
        List<IThemeRule> ThemeRules { get; }
        List<IFooterData> FooterData { get; }
    }

    /// <summary>
    /// The theme definition that can be grouped per individual page.
    /// </summary>
    public class Theme : ITheme
    {
        public string BackgroundColor { get; set; }
        public string BackgroundImage { get; set; }
        public List<IThemeRule> ThemeRules { get; set; } = new List<IThemeRule>();
        public List<IFooterData> FooterData { get; set; } = new List<IFooterData>();


        public IStyle this[int level] => ThemeRules.First(x => x.LevelId == level).Style;
    }
}