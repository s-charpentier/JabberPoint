namespace JabberPoint.Domain.Themes
{
    /// <summary>
    /// interface for footerdata
    /// </summary>
    public interface IFooterData
    {
        /// <summary>
        /// the text shown in the footer
        /// </summary>
        string Text { get;}
        /// <summary>
        /// the level that determines how important the footerdata is
        /// </summary>
        int Level { get; }
    }
    /// <summary>
    /// dataholder for data shown in the footer.
    /// </summary>
    public class FooterData : IFooterData
    {
        public string Text { get; set; }
        public int Level { get; set; }
    }
}