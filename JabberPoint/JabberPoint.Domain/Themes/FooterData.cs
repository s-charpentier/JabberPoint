namespace JabberPoint.Domain.Themes
{
    public interface IFooterData
    {
        string Text { get;}
        int Level { get; }
    }
    public class FooterData:IFooterData
    {
        public string Text { get; set; }
        public int Level { get; set; }
    }
}