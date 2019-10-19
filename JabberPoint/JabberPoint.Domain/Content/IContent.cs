using System;
using System.Collections.Generic;
using System.Text;
using JabberPoint.Domain.Content.Behaviours;
using JabberPoint.Domain.Helpers;

namespace JabberPoint.Domain.Content
{
    /// <summary>
    /// interface for the content class
    /// </summary>
    public interface IContent : IMetadataProvider
    {
        /// <summary>
        /// List of composite pattern components, in this case called ContentBehaviours.
        /// A contentbehaviour determines the type of content and what is shown in it.
        /// </summary>
        List<IContentBehaviour> Behaviours { get; }

        /// <summary>
        /// Template function that returns the behaviour of a specific behaviour type
        /// </summary>
        /// <typeparam name="T">the behaviour to return</typeparam>
        /// <returns> the first behaviour in the behaviourlist that matches the given behaviour</returns>
        T GetBehaviour<T>() where T : IContentBehaviour;


        /// <summary>
        /// Template function that adds a behaviour of a given type to the Content object
        /// </summary>
        /// <typeparam name="T">the specific type of content to be returned</typeparam>
        /// <returns>the created behaviour</returns>
        T AddBehaviour<T>() where T : IContentBehaviour, new();
    }
}
