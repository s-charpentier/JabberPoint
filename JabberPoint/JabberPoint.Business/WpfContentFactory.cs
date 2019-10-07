using JabberPoint.Domain.Content;
using JabberPoint.Domain.Content.Behaviours;
using JabberPoint.Domain.View.Wpf.Content.Behaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JabberPoint.Business
{


    public class WpfTextContentFactory : IContentFactory
    {
        private string _text;
        private int _level;
        public WpfTextContentFactory(string text, int level)
        {
            this._text = text;
            this._level = level;
        }
        public IContent GetContent()
        {
            Content content = new Content();
            WpfTextBehaviour tb = content.AddBehaviour<WpfTextBehaviour>();
            LevelledBehaviour lb = content.AddBehaviour<LevelledBehaviour>();

            tb.Text = this._text;
            lb.Level = this._level;

            return content;
        }
    }

    public class WpfImageContentFactory : IContentFactory
    {
        private string _reference;
        public WpfImageContentFactory(string reference)
        {
            this._reference = reference;
        }
        public IContent GetContent()
        {
            Content content = new Content();
            WpfMediaBehaviour mb = content.AddBehaviour<WpfMediaBehaviour>();

            mb.Reference = this._reference;

            return content;
        }
    }
    
}
