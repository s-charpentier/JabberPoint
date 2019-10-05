using System;
using System.Collections.Generic;
using System.Text;

namespace JabberPoint.Domain.Content.Behaviours
{
    
    public interface IListBehaviour : IContentBehaviour
    {
        char Separator { get; set; }
        List<IListableBehaviour> ContentList { get; set; }

    }
    public class ListBehaviour : ContentBehaviourDrawer, IContentBehaviour
    {
        public IContent Parent { get; set; }

        public char Separator { get; set; }
        public List<IListableBehaviour> ContentList { get; set; }

    }
}
