using System;
using System.Collections.Generic;
using System.Text;

namespace JabberPoint.Domain.Content.Behaviours
{
    public class ListBehaviour : IContentBehaviour
    {
        public IContent Parent { get; set; }

        public char Separator { get; set; }
        public List<IListableBehaviour> ContentList { get; set; }

    }
}
