using System;
using System.Collections.Generic;
using System.Text;
using JabberPoint.Domain.Content;

namespace JabberPoint.Domain
{
    public class Slide : ISlide
    {
        public List<IContent> Contents { get; private set; }

        public Slide()
        {
            this.Contents = new List<IContent>();
        }
    }
}
