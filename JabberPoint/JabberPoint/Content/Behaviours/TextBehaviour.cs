using System;
using System.Collections.Generic;
using System.Text;

namespace JabberPoint.Domain.Content.Behaviours
{
    public class TextBehaviour : IListableBehaviour
    {
        public IContent Parent { get; private set; }

        public string Text { get; private set; }

    }
}
