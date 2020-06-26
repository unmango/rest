using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;

namespace UnMango.Rest.Serialization
{
    public interface ISerializerCollection :
        ILookup<ContentType, ISerializer>,
        IEnumerable<ISerializer>
    { }
}
