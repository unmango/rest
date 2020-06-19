using System;
using System.Net.Http;
using Microsoft.Extensions.Options;

namespace UnMango.Rest.Internal
{
    public class DefaultRestClientFactory : IRestClientFactory
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IOptionsMonitor<RestClientOptions> _optionsMonitor;

        public DefaultRestClientFactory(
            IHttpClientFactory clientFactory,
            IOptionsMonitor<RestClientOptions> optionsMonitor)
        {
            _clientFactory = clientFactory;
            _optionsMonitor = optionsMonitor;
        }

        public IRestClient Create(string name)
        {
            var client = _clientFactory.CreateClient(name);
            var options = _optionsMonitor.Get(name);

            throw new NotImplementedException();
        }
    }
}
