using System.Collections.Generic;
using UnMango.Rest.Serialization;

namespace UnMango.Rest
{
    public class RestClientOptions
    {
        public RestClientOptions()
        {
            ClientSerializers = new Dictionary<string, ISerializerCollection>();
        }
        
        internal IDictionary<string, ISerializerCollection> ClientSerializers { get; }
    }
}
