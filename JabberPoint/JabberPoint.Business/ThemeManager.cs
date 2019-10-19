
using System.Linq;
using System.Collections;
using JabberPoint.Data;
using JabberPoint.Domain.Themes;
using System.Collections.Generic;
using JabberPoint.Domain;

namespace JabberPoint.Business
{
    public class ThemeManager
    {
        public static void ThemeLoader(string inputUrl = "./theme1.xml")
            => Loadthemes(inputUrl);
        private static void Loadthemes(string inputUrl)
        {
            JabberPoint.Data.theme data;

            ThemeXmlLoader loader = new ThemeXmlLoader(inputUrl);

            data = loader.RootObject;

            var themes = Themes.GetSingleton();
            var theme = new JabberPoint.Domain.Themes.ThemeCollection();
            theme.Name = inputUrl;
            foreach (var filter in data.themefilters)
            {
                if (string.Compare(filter.@for, "default", true) == 0)
                {
                   
                    theme.PageThemes.Add(-1, SetPageTheme(filter,data.styles));
                }
                else
                {
                    foreach(var page in filter.@for.Split(','))
                    {                      
                         theme.PageThemes.Add(int.Parse(page), SetPageTheme(filter, data.styles));
                    }
                }
            }
            themes.SetList(new List<ThemeCollection>() { theme });
            themes.SetCurrentTheme (theme.Name);
            
        }

        private static void addTheme(JabberPoint.Data.theme data, string inputUrl)
        {
            var theme = new JabberPoint.Domain.Themes.ThemeCollection
            {
                Name = inputUrl
            };
            foreach (var filter in data.themefilters)
            {
                if (string.Compare(filter.@for, "default", true) == 0)
                {

                    theme.PageThemes.Add(-1, SetPageTheme(filter, data.styles));
                }
                else
                {
                    foreach (var page in filter.@for.Split(','))
                    {
                        theme.PageThemes.Add(int.Parse(page), SetPageTheme(filter, data.styles));
                    }
                }
            }
        }
        private static ITheme SetPageTheme(themeThemefilter filter, themeStyle[] themeStyles)
        {
            var pagetheme = new Theme
            {
                BackgroundImage = filter.backgroundimage.value,
                BackgroundColor = filter.backgroundColor.value
            };
            foreach (var level in filter.levels)
            {
                IThemeRule themeRule = new ThemeRule()
                {
                    LevelId = level.level,
                    Style = SetStyle(themeStyles.First(x=>x.id== level.style)),
                    
                };
                pagetheme.ThemeRules.Add(themeRule);

            }

            if (filter.showMeta!=null)
            foreach (var meta in filter.showMeta)
            {
                IFooterData footer = new FooterData()
                {
                    Text = $"[{meta.name}]",
                    Level = meta.level
                };
                pagetheme.FooterData.Add(footer);
            }

            return pagetheme;
        }
        private static IStyle SetStyle(themeStyle themeStyle)
        {
            var style = new Style()
            {
                Font = themeStyle.FontFamily.value,
                FontColor = themeStyle.FontColor.value,
                FontSize = themeStyle.FontSize.value,
                FontStyle = string.Compare(themeStyle.FontStyle.value, "italic", true) == 0 ? Domain.Helpers.FontStyle.Italic : Domain.Helpers.FontStyle.Normal,
                FontWeight = string.Compare(themeStyle.FontWeight.value, "bold", true) == 0 ? Domain.Helpers.FontWeight.Bold : Domain.Helpers.FontWeight.Normal,
                TextDecoration = SetDecoration(themeStyle.TextDecoration),
                TextAlign = SetAlignment(themeStyle.TextAlign)
            };

            return style;
        }
        private static Domain.Helpers.TextDecoration SetDecoration(themeStyleTextDecoration decoration)
        {
            var compare = decoration.value.ToUpper();

            switch (compare)
            {
                case "SUBSCRIPT":
                    return Domain.Helpers.TextDecoration.subscript;
                case "SUPERSCRIPT":
                    return Domain.Helpers.TextDecoration.superscript;
                case "UNDERLINED":
                    return Domain.Helpers.TextDecoration.Underlined;
                default:
                    return Domain.Helpers.TextDecoration.Normal;
            }

        }
        private static Domain.Helpers.Alignment SetAlignment(themeStyleTextAlign decoration)
        {
            var compare = decoration.value.ToUpper();

            switch (compare)
            {
                case "CENTERED":
                    return Domain.Helpers.Alignment.Centered;
                case "LEFT":
                    return Domain.Helpers.Alignment.Left;
                default:
                    return Domain.Helpers.Alignment.Right;
            }

        }
    }
}
