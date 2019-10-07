using System;
using System.Collections.Generic;
using System.Text;

namespace JabberPoint.Domain.Content.Behaviours
{
    public interface IMediaBehaviour<T> : IDrawableBehaviour<T>
    {
        string Reference { get; set; }
        string IsPlaying { get; }
    }
    public class MediaBehaviour : IMediaBehaviour<object>
    {
        public IContent Parent { get; set; }
        public string Reference { get; set; }
        public string IsPlaying { get; private set; }
        public object Draw() => throw new InvalidOperationException("please only use view specific classes");
    }
}
