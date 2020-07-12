using Microsoft.Extensions.Options;

namespace UnMango.Rest.Internal
{
    /// <inheritdoc />
    public class DefaultRestClientFactory : IRestClientFactory
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IOptionsMonitor<RestClientOptions> _optionsMonitor;

        /// <summary>
        /// Initializes a new instance of a <see cref="DefaultHttpClientFactory"/> to
        /// create <see cref="IRestClient"/>s using <paramref name="clientFactory"/>
        /// to create the underlying <see cref="System.Net.Http.HttpClient"/> and <paramref name="optionsMonitor"/>
        /// to fetch options to configure the <see cref="IRestClient"/>.
        /// </summary>
        /// <param name="clientFactory">
        /// Used to create the underlying <see cref="System.Net.Http.HttpClient"/>
        /// used by the <see cref="IRestClient"/>.
        /// </param>
        /// <param name="optionsMonitor">Fetches options to configure the created <see cref="IRestClient"/>.</param>
        public DefaultRestClientFactory(
            IHttpClientFactory clientFactory,
            IOptionsMonitor<RestClientOptions> optionsMonitor)
        {
            _clientFactory = clientFactory;
            _optionsMonitor = optionsMonitor;
        }

        /// <inheritdoc />
        public IRestClient Create(string name)
        {
            var client = _clientFactory.CreateClient(name);
            var options = _optionsMonitor.Get(name);

            return new RestClient(client, options.ClientSerializers[name]);
        }
    }
}
