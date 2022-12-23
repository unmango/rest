using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using UnMango.Rest.Serialization;

namespace UnMango.Rest.Internal
{
    internal class RestClient : IRestClient
    {
        public RestClient(HttpClient client)
        {
            HttpClient = client ?? throw new ArgumentNullException(nameof(client));
        }

        public HttpClient HttpClient { get; }
        
        public Task SendAsync(IRestRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
