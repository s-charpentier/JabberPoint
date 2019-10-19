using System;
using System.Collections.Generic;
using System.Text;

namespace JabberPoint.Domain
{
    /// <summary>
    /// interface for Slideshow class
    /// </summary>
    public interface ISlideshow:IMetadataProvider
    {
        /// <summary>
        /// Metadata loaded from the slideshow data, mapping metadata keys to values
        /// </summary>
        Dictionary<string, string> MetaData { get; }
        /// <summary>
        /// An ordered list of slides that will be displayed
        /// </summary>
        List<ISlideSection> Slides { get; }
        /// <summary>
        /// List of footers, mapped to their page number
        /// </summary>
        Dictionary<int,ISlideSection> Footers { get; }
        /// <summary>
        /// retrieves the footer for a specific page.
        /// </summary>
        /// <param name="page">the page number for which to retrieve a footer</param>
        /// <returns>the footer of the given page number</returns>
        ISlideSection GetFooter(int page);
    }
}
