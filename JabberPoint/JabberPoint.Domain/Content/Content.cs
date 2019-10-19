using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JabberPoint.Domain.Content.Behaviours;
using JabberPoint.Domain.Helpers;

namespace JabberPoint.Domain.Content
{
    /// <summary>
    /// Content is a composite pattern client class, containing a list of components.
    /// Components are, in this case, called ContentBehaviours.
    /// </summary>
    public class Content : IContent
    {
        public List<IContentBehaviour> Behaviours { get; private set; }
        private IMetadataProvider _parent;
        public Content(IMetadataProvider parent)
        {
            this.Behaviours = new List<IContentBehaviour>();
            _parent = parent;
        }

        public T AddBehaviour<T>() where T : IContentBehaviour, new() {
            T behaviour = new T { Parent = this };
            this.Behaviours.Add(behaviour);
            return behaviour;
        }
        
        public T GetBehaviour<T>() where T : IContentBehaviour {
            return this.Behaviours.OfType<T>().First();
        }

        public string GetValueForKey(string key)
        {
            //if each content piece had a metadata object, an inbetween check is needed here.
            return _parent.GetValueForKey(key);
        }

        public string ReplaceTextWithMetaData(string text)
        {
            return _parent.ReplaceTextWithMetaData(text);
        }
    }
}
