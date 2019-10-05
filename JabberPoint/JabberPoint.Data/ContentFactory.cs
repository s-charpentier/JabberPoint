﻿using JabberPoint.Domain.Content;
using JabberPoint.Domain.Content.Behaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JabberPoint.Data
{
    public abstract class ContentFactory
    {
        public abstract IContent GetContent();
    }

    public class TextContentFactory : ContentFactory
    {
        private string _text;
        private int _level;
        public TextContentFactory(string text, int level)
        {
            this._text = text;
            this._level = level;
        }
        public override IContent GetContent()
        {
            Content content = new Content();
            TextBehaviour tb = content.AddBehaviour<TextBehaviour>();
            LevelledBehaviour lb = content.AddBehaviour<LevelledBehaviour>();

            tb.Text = this._text;
            lb.Level = this._level;

            return content;
        }
    }

    public class ImageContentFactory : ContentFactory
    {
        private string _reference;
        public ImageContentFactory(string reference)
        {
            this._reference = reference;
        }
        public override IContent GetContent()
        {
            Content content = new Content();
            MediaBehaviour mb = content.AddBehaviour<MediaBehaviour>();

            mb.Reference = this._reference;

            return content;
        }
    }

    public class ListContentFactory : ContentFactory
    {
        private char _separator;
        List<IListableBehaviour> _listables;
        public ListContentFactory(char separator, params IListableBehaviour[] listables) : this(separator, listables.AsEnumerable()) { }
        public ListContentFactory(char separator, IEnumerable<IListableBehaviour> listables)
        {
            this._separator = separator;
            this._listables = listables.ToList();

        }
        public override IContent GetContent()
        {
            Content content = new Content();
            ListBehaviour lb = content.AddBehaviour<ListBehaviour>();

            lb.Separator = this._separator;
            lb.ContentList = this._listables;

            return content;
        }
    }
}
