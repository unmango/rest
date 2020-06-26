using Microsoft.Extensions.DependencyInjection;

namespace UnMango.Rest.DependencyInjection
{
    public class RestClientBuilder : IRestClientBuilder
    {
        public RestClientBuilder(IHttpClientBuilder httpClientBuilder)
        {
            HttpClientBuilder = httpClientBuilder;
        }

        public IHttpClientBuilder HttpClientBuilder { get; }

        public string Name => HttpClientBuilder.Name;

        public IServiceCollection Services => HttpClientBuilder.Services;
    }
}
