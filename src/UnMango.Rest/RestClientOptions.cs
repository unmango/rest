using System;
using System.Collections.Generic;
using System.Text;
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
