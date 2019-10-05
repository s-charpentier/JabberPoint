using System;
using System.Collections.Generic;
using System.Text;
using JabberPoint.Domain.Content;

namespace JabberPoint.Domain
{
    public interface ISlide
    {

        List<IContent> Contents { get; }
    }
}
