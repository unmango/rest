using System;
using System.Net.Http;
using UnMango.Rest.Serialization;

namespace UnMango.Rest
{
    using InternalRestClient = Internal.RestClient;
    
    public static class RestClient
    {
        public static IRestClient Create(HttpClient client, ISerializerCollection? serializers = null)
        {
            if (client == null) throw new ArgumentNullException(nameof(client));
            serializers ??= SerializerCollection.Instance;
            
            return new InternalRestClient(client, serializers);
        }
    }
}
