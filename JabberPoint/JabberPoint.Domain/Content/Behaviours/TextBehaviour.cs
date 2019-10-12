using System;
using System.Collections.Generic;
using System.Text;

namespace JabberPoint.Domain.Content.Behaviours
{
    public interface ITextBehaviour : IListableBehaviour
    {
        string Text { get; set; }
    }
    public abstract class TextBehaviour<T> : ITextBehaviour, IDrawableBehaviour<T>
    {
        public IContent Parent { get; set; }
        public string Text { get; set; }
        public virtual  T Draw(int pageNr) => throw new InvalidOperationException("please only use view specific classes");
    }
}
