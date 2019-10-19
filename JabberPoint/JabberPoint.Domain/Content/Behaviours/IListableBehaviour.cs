using System;
using System.Collections.Generic;
using System.Text;

namespace JabberPoint.Domain.Content.Behaviours
{
    /// <summary>
    /// composite pattern interface for leaves and composites that can be added to a List composite
    /// </summary>
    public interface IListableBehaviour : IContentBehaviour
    {
    }
}
