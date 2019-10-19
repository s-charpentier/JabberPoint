using System;
using System.Collections.Generic;
using System.Text;

namespace JabberPoint.Domain.Content.Behaviours
{
    /// <summary>
    /// interface for a levelled behaviour
    /// </summary>
    public interface ILevelledBehaviour : IContentBehaviour
    {
        /// <summary>
        /// The level that determines the importance of the levelledbehaviour. Lower is more important.
        /// </summary>
        int Level { get; set; }
    }
    /// <summary>
    /// A composite pattern leaf that contains a level-integer, representing the importance level of the content.
    /// </summary>
    public class LevelledBehaviour : ILevelledBehaviour
    {
        public IContent Parent { get; set; }
        /// <summary>
        /// The level that determines the importance of the levelledbehaviour. Lower is more important.
        /// </summary>
        public int Level { get; set; }
        public void Accept(IContentBehaviourVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
