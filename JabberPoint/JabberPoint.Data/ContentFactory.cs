using JabberPoint.Domain.Content;
using JabberPoint.Domain.Content.Behaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JabberPoint.Data
{
    abstract class ContentFactory
    {
        public abstract IContent GetContent();
    }

    class TextContentFactory : ContentFactory
    {
        private string text;
        private int level;
        public TextContentFactory(string text, int level)
        {
            this.text = text;
            this.level = level;
        }
        public override IContent GetContent()
        {
            Content content = new Content(0, 0, 0, 0);
            TextBehaviour tb = content.AddBehaviour<TextBehaviour>();
            LevelledBehaviour lb = content.AddBehaviour<LevelledBehaviour>();

            tb.Text = this.text;
            lb.Level = this.level;

            return content;
        }
    }

    class ImageContentFactory : ContentFactory
    {
        private string reference;
        public ImageContentFactory(string reference)
        {
            this.reference = reference;
        }
        public override IContent GetContent()
        {
            Content content = new Content(0, 0, 0, 0);
            MediaBehaviour mb = content.AddBehaviour<MediaBehaviour>();

            mb.Reference = this.reference;

            return content;
        }
    }

    class ListContentFactory : ContentFactory
    {
        private char separator;
        List<IListableBehaviour> listables;
        public ListContentFactory(char separator, params IListableBehaviour[] listables) : this(separator, listables.AsEnumerable()) { }
        public ListContentFactory(char separator, IEnumerable<IListableBehaviour> listables)
        {
            this.separator = separator;
            this.listables = listables.ToList();

        }
        public override IContent GetContent()
        {
            Content content = new Content(0, 0, 0, 0);
            ListBehaviour lb = content.AddBehaviour<ListBehaviour>();

            lb.Separator = this.separator;
            lb.ContentList = this.listables;

            return content;
        }
    }
}
