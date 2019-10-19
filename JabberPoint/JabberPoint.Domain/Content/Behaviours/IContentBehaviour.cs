using System;
using System.Collections.Generic;
using System.Text;

namespace JabberPoint.Domain.Content.Behaviours
{
    /// <summary>
    /// composite pattern interface for leaves and composites
    /// </summary>
    public interface IContentBehaviour
    {
        /// <summary>
        /// the content component to which a leaf or composite belongs
        /// </summary>
        IContent Parent { get; set; }
        /// <summary>
        /// Accept method for visitor pattern\n
        /// should ONLY contain the following code:\n
        /// visitor.Visit(this);
        /// </summary>
        /// <param name="visitor">The visitor to call</param>
        void Accept(IContentBehaviourVisitor visitor);
    }

}
