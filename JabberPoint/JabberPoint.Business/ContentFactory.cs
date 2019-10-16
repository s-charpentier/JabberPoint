using JabberPoint.Domain;
using JabberPoint.Domain.Content;
using JabberPoint.Domain.Content.Behaviours;
using JabberPoint.Domain.View.Wpf.Content.Behaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JabberPoint.Business
{
    public interface IContentFactory
    {
        IContent GetContent(IMetadataProvider parent);
    }

    public class TextContentFactory: IContentFactory
    {
        private string _text;
        private int _level;
        public TextContentFactory(string text, int level)
        {
            this._text = text;
            this._level = level;
        }
        public IContent GetContent(IMetadataProvider parent)
        {
            Content content = new Content(parent);
            WpfTextBehaviour tb = content.AddBehaviour<WpfTextBehaviour>();
            ILevelledBehaviour lb = content.AddBehaviour<LevelledBehaviour>();

            tb.Text = this._text;
            lb.Level = this._level;

            return content;
        }
    }

    public class ImageContentFactory: IContentFactory
    {
        private string _reference;
        public ImageContentFactory(string reference)
        {
            this._reference = reference;
        }
        public IContent GetContent(IMetadataProvider parent)
        {
            Content content = new Content( parent);
            WpfMediaBehaviour mb = content.AddBehaviour<WpfMediaBehaviour>();

            mb.Reference = this._reference;

            return content;
        }
    }

    public class ListContentFactory : IContentFactory
    {
        private char _separator;
        List<IListableBehaviour> _listables;
        public ListContentFactory(char separator, params IListableBehaviour[] listables) : this(separator, listables.AsEnumerable()) { }
        public ListContentFactory(char separator, IEnumerable<IListableBehaviour> listables)
        {
            this._separator = separator;
            this._listables = listables.ToList();

        }
        public IContent GetContent(IMetadataProvider parent)
        {
            Content content = new Content( parent);
            ListBehaviour lb = content.AddBehaviour<ListBehaviour>();

            lb.Separator = this._separator;
            lb.ContentList = this._listables;

            return content;
        }
    }
}
