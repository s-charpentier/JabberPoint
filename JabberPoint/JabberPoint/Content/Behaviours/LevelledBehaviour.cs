﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JabberPoint.Domain.Content.Behaviours
{
    public class LevelledBehaviour : IContentBehaviour
    {
        public IContent Parent { get; set; }
        public int Level { get; set; }
    }
}
