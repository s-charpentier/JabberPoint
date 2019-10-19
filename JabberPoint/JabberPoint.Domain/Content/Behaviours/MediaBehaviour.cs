using System;
using System.Collections.Generic;
using System.Text;

namespace JabberPoint.Domain.Content.Behaviours
{
    /// <summary>
    /// interface for media behaviours
    /// </summary>
    public interface IMediaBehaviour : IContentBehaviour
    {
        /// <summary>
        /// url to the media that should be displayed.
        /// </summary>
        string Reference { get; set; }
    }
    /// <summary>
    /// A media behaviour is a composite pattern leaf that contains a reference to media other than text (e.g. images).
    /// </summary>
    public class MediaBehaviour : IMediaBehaviour
    {
        public IContent Parent { get; set; }
        public string Reference { get; set; }
        public void Accept(IContentBehaviourVisitor visitor) {
            visitor.Visit(this);
        }
    }
}
