using System;
using System.Collections.Generic;
using System.Text;
using JabberPoint.Domain.Content;

namespace JabberPoint.Domain.Content.Behaviours
{
    /// <summary>
    /// interface for list behaviours
    /// </summary>
    public interface IListBehaviour : IContentBehaviour
    {
        /// <summary>
        /// the separator contains the character used to separate list items in a list
        /// </summary>
        char Separator { get; set; }
        /// <summary>
        /// List of listable behaviours
        /// </summary>
        List<IListableBehaviour> ContentList { get; set; }

    }
    /// <summary>
    /// A composite pattern composite that contains a list of ListableBehaviours.
    /// </summary>
    public class ListBehaviour : IListBehaviour
    {
        public IContent Parent { get; set; }

        public char Separator { get; set; }
        public List<IListableBehaviour> ContentList { get; set; }

        public void Accept(IContentBehaviourVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
