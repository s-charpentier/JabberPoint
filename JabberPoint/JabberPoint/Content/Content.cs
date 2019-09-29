﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JabberPoint.Domain.Content.Behaviours;
using JabberPoint.Domain.Helpers;

namespace JabberPoint.Domain.Content
{
    public class Content : IContent
    {
        public List<IContentBehaviour> Behaviours { get; private set; }
        public Bounds Bounds { get; private set; }

        public Content(int x,int y, int height, int width, params IContentBehaviour[] behaviours) : this(new Bounds(x, y, height, width), behaviours) { }
        public Content (Bounds bounds,params IContentBehaviour[] behaviours ) : this(bounds,behaviours.AsEnumerable()) { }

        public Content(int x, int y, int height, int width, IEnumerable<IContentBehaviour> behaviours) : this(new Bounds(x, y, height, width), behaviours) { }
        public Content (Bounds bounds,IEnumerable<IContentBehaviour> behaviours) 
        {
            Behaviours = behaviours.ToList();
            Bounds = bounds;
        }
        public Content (params IContentBehaviour[] behaviours) : this(behaviours) { }
    }
}
