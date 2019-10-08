using System;
using System.Collections.Generic;
using System.Text;
using JabberPoint.Domain.Content;

namespace JabberPoint.Domain
{
    public class Footer : IFooter
    {
        public SortedList<int, IContent> Contents { get; private set; }

       
        public Footer()
        {
            this.Contents = new SortedList<int, IContent>();
        }
    }
}
