using System;
using System.Collections.Generic;
using System.Text;

namespace JabberPoint.Domain.Content.Behaviours
{
    public interface IMediaBehaviour : IContentBehaviour
    {
        string Reference { get; set; }
        string IsPlaying { get; }
    }
    public abstract class MediaBehaviour<T> : IMediaBehaviour, IDrawableBehaviour<T>
    {
        public IContent Parent { get; set; }
        public string Reference { get; set; }
        public string IsPlaying { get; private set; }
        public virtual T Draw(int pageNr) => throw new InvalidOperationException("please only use view specific classes");
    }
}
