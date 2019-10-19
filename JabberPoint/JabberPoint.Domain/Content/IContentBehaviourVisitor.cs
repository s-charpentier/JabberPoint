using JabberPoint.Domain.Content.Behaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberPoint.Domain.Content
{
    /// <summary>
    /// Visitor pattern interface for communication with behaviours without typechecks
    /// </summary>
    public interface IContentBehaviourVisitor
    {
        /// <summary>
        /// function that is called from a behaviour, passing itself as an argument.
        /// </summary>
        /// <param name="behaviour">the behaviour that called this function</param>
        void Visit(TextBehaviour behaviour);
        /// <summary>
        /// function that is called from a behaviour, passing itself as an argument.
        /// </summary>
        /// <param name="behaviour">the behaviour that called this function</param>
        void Visit(MediaBehaviour behaviour);
        /// <summary>
        /// function that is called from a behaviour, passing itself as an argument.
        /// </summary>
        /// <param name="behaviour">the behaviour that called this function</param>
        void Visit(LevelledBehaviour behaviour);
        /// <summary>
        /// function that is called from a behaviour, passing itself as an argument.
        /// </summary>
        /// <param name="behaviour">the behaviour that called this function</param>
        void Visit(ListBehaviour behaviour);
    }
}
