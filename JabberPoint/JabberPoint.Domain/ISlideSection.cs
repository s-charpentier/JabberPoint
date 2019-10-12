using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JabberPoint.Domain.Content;

namespace JabberPoint.Domain
{

    public interface ISlideSection
    {
        SortedList<int,IContent> Contents { get; }
    }
}
