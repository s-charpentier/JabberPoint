using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberPoint.Domain.Content.Behaviours
{

    
    public interface IDrawableBehaviour<T> : IContentBehaviour
    {
        T Draw();
    }
}
