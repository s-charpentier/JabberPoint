using System;
using System.Collections.Generic;
using System.Text;

namespace JabberPoint.Domain.Content.Behaviours
{
    public class MediaBehaviour : IContentBehaviour
    {
        public IContent Parent { get; private set; }


        public string Reference { get; private set; }
        public string IsPlaying { get; private set; }
    }
}
