using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnMango.Rest.Serialization;

namespace UnMango.Rest.Internal
{
    internal class RestClient : IRestClient
    {
        public RestClient(HttpClient client, ISerializerCollection serializers)
        {
            HttpClient = client ?? throw new ArgumentNullException(nameof(client));
            Serializers = serializers ?? throw new ArgumentNullException(nameof(serializers));
        }

        public HttpClient HttpClient { get; }
        
        public ISerializerCollection Serializers { get; }
        
        public Task SendAsync(IRestRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
