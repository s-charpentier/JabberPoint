using System;
using System.Collections.Generic;
using System.Text;

namespace JabberPoint.Domain.Content.Behaviours
{
    public interface ITextBehaviour<T> : IListableBehaviour<T>
    {
        string Text { get; set; }
    }
    public class TextBehaviour : ITextBehaviour<object>
    {
        public IContent Parent { get; set; }
        public string Text { get; set; }
        public object Draw() => throw new InvalidOperationException("please only use view specific classes");
    }
}
