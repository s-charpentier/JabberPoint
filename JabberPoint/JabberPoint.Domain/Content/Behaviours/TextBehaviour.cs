using System;
using System.Collections.Generic;
using System.Text;

namespace JabberPoint.Domain.Content.Behaviours
{
    public interface ITextBehaviour : IListableBehaviour
    {
        string Text { get; set; }
    }
    public class TextBehaviour : ITextBehaviour
    {
        public IContent Parent { get; set; }
        public string Text { get; set; }
    }
}
