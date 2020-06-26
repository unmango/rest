using System.Collections;
using System.Collections.Generic;

namespace UnMango.Rest
{
    public interface IRestRequest
    {
        IEnumerable<KeyValuePair<string, string>> QueryParameters { get; }
    }
}
