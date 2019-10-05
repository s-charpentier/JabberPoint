﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JabberPoint.Domain.Content.Behaviours
{
    public interface IMediaBehaviour : IContentBehaviour
    {
        string Reference { get; set; }
        string IsPlaying { get; }
    }
    public class MediaBehaviour : ContentBehaviourDrawer, IContentBehaviour
    {
        public IContent Parent { get; set; }
        public string Reference { get; set; }
        public string IsPlaying { get; private set; }
    }
}
