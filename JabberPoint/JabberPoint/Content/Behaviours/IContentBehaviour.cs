using System;
using System.Collections.Generic;
using System.Text;

namespace JabberPoint.Domain.Content.Behaviours
{
    public interface IContentBehaviour
    {
         IContent Parent { get; set; }
    }
}
