using System.Net.Http;
using Microsoft.Extensions.Options;

namespace UnMango.Rest.Internal
{
    /// <inheritdoc />
    public class DefaultRestClientFactory : IRestClientFactory
    {
        private readonly IOptionsMonitor<RestClientOptions> _optionsMonitor;

        /// <summary>
        /// Initializes a new instance of a <see cref="DefaultRestClientFactory"/> that instantiates a new
        /// <see cref="System.Net.Http.HttpClient"/> to use for each request to <see cref="Create"/>
        /// and <paramref name="optionsMonitor"/> to fetch options to configure the <see cref="IRestClient"/>.
        /// </summary>
        /// <param name="optionsMonitor">Fetches options to configure the created <see cref="IRestClient"/>.</param>
        public DefaultRestClientFactory(IOptionsMonitor<RestClientOptions> optionsMonitor)
        {
            _optionsMonitor = optionsMonitor;
        }

        /// <inheritdoc />
        public IRestClient Create(string name)
        {
            var client = new HttpClient();
            var options = _optionsMonitor.Get(name);

            return new RestClient(client);
        }
    }
}
