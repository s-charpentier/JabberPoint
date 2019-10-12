using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabberPoint.Domain
{
    public interface IMetadataProvider
    {
        string GetValueForKey(string key);
    }
}
