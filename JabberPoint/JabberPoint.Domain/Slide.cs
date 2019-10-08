﻿using System;
using System.Collections.Generic;
using System.Text;
using JabberPoint.Domain.Content;

namespace JabberPoint.Domain
{
    public class Slide : ISlide
    {
        public SortedList<int, IContent> Contents { get; private set; }

       
        public Slide()
        {
            this.Contents = new SortedList<int, IContent>();
        }
    }
}
