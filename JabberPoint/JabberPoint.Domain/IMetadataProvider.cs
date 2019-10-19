using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberPoint.Domain
{
    /// <summary>
    /// interface for exchanging meta data between slideshow, slidesection and content.
    /// </summary>
    public interface IMetadataProvider
    {
        /// <summary>
        /// finds the metadata value for a given metadata key.
        /// </summary>
        /// <param name="key">name of the metadata</param>
        /// <returns>the value of the given key from the metadata key-value list</returns>
        string GetValueForKey(string key);
        /// <summary>
        /// finds and replaces all instances in a text that can be interpreted as metadata.
        /// </summary>
        /// <param name="text">The text, possibly containing metadata keys</param>
        /// <returns>A copy of the given text, where metadata keys have been replaced with their values</returns>
        string ReplaceTextWithMetaData(string text);
    }
}
