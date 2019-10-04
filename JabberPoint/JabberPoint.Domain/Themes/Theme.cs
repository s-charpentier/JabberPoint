using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace JabberPoint.Domain.Themes
{
    public class Theme
    {
        public string Name { get; private set; }
        public List<ThemeRule> ThemeRules { get; private set; }

        public Style this[int level]=> ThemeRules.First(x=>x.LevelId == level).Style;         

    }
}
