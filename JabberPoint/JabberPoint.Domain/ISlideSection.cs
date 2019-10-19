using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JabberPoint.Domain.Content;

namespace JabberPoint.Domain
{
    /// <summary>
    /// interface for SlideSection
    /// </summary>
    public interface ISlideSection : IMetadataProvider
    {
        /// <summary>
        /// all content to display in a slide or footer.
        /// </summary>
        SortedList<int,IContent> Contents { get; }
    }
}
