using System;
using System.Collections.Generic;
using System.Text;

namespace JabberPoint.Domain.Content.Behaviours
{
    /// <summary>
    /// interface for text behaviours
    /// </summary>
    public interface ITextBehaviour : IListableBehaviour
    {
        /// <summary>
        /// the text that should be displayed in the content.
        /// </summary>
        string Text { get; set; }
    }
    /// <summary>
    /// a textbehaviour is a composite pattern leaf that contains text to be displayed.
    /// </summary>
    public class TextBehaviour : ITextBehaviour
    {
        public IContent Parent { get; set; }
        public string Text { get; set; }
        public void Accept(IContentBehaviourVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
