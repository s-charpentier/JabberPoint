using System;
using System.Collections.Generic;
using System.Text;

namespace JabberPoint.Domain.Content.Behaviours
{
    public class MediaBehaviour : IContentBehaviour
    {
        public IContent Parent { get; set; }


        public string Reference { get; set; }
        public string IsPlaying { get; private set; }
    }
}
