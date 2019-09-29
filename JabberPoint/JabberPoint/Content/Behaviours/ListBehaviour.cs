using System;
using System.Collections.Generic;
using System.Text;

namespace JabberPoint.Domain.Content.Behaviours
{
    public class ListBehaviour : IContentBehaviour
    {
        public IContent Parent { get; private set; }

        public char Separator { get; private set; }
        public List<IListableBehaviour> ContentList { get; private set; }

    }
}
