using System;
using System.Collections.Generic;
using System.Text;

namespace JabberPoint.Domain.Content.Behaviours
{
    
    public interface IListBehaviour<T> : IContentBehaviour
    {
        char Separator { get; set; }
        List<IListableBehaviour<T>> ContentList { get; set; }

    }
    public class ListBehaviour : IListBehaviour<object>
    {
        public IContent Parent { get; set; }

        public char Separator { get; set; }
        public List<IListableBehaviour<object>> ContentList { get; set; }

    }
}
