using System;
using System.Collections.Generic;
using System.Text;

namespace JabberPoint.Domain.Content.Behaviours
{
    public class TextBehaviour : IListableBehaviour
    {
        public IContent Parent { get; set; }
        public string Text { get; set; }
    }
}
