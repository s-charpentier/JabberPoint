﻿using System;
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

        public Content()
        {
            this.Behaviours = new List<IContentBehaviour>();
        }

        

        /// <summary>
        /// Template function that adds a behaviour of a given type to the Content object
        /// </summary>
        /// <typeparam name="T">the specific type of content to be returned</typeparam>
        /// <returns>the created behaviour</returns>
        public T AddBehaviour<T>() where T : IContentBehaviour, new() {
            T behaviour = new T { Parent = this };
            this.Behaviours.Add(behaviour);
            return behaviour;
        }
        
        /// <summary>
        /// Template function that returns the behaviour of a specific behaviour type
        /// </summary>
        /// <typeparam name="T">the behaviour to return</typeparam>
        /// <returns> the first behaviour in the behaviourlist that matches the given behaviour</returns>
        public T GetBehaviour<T>() where T : IContentBehaviour {
            return this.Behaviours.OfType<T>().First();
        }
    }
}
