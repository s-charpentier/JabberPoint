using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JabberPoint.Domain.Content.Behaviours;
using JabberPoint.Domain.Helpers;

namespace JabberPoint.Domain.Content
{
    public class Content : IContent
    {
        public List<IContentBehaviour> Behaviours { get; private set; }

        /**
         * function AddBehaviour
         * Template function that adds a behaviour of a given type to the Content object
         * \return the created behaviour
         */
        public T AddBehaviour<T>() where T : IContentBehaviour, new() {
            T behaviour = new T { Parent = this };
            this.Behaviours.Add(behaviour);
            return behaviour;
        }

        /**
         * function GetBehaviour
         * Template function that returns the behaviour of a specific behaviour type
         * \return the first behaviour in the behaviourlist that matches the given behaviour
         */
        public T GetBehaviour<T>() where T : IContentBehaviour {
            return this.Behaviours.OfType<T>().First();
        }
    }
}
