using Microsoft.Extensions.DependencyInjection;

namespace UnMango.Rest.DependencyInjection
{
    public interface IRestClientBuilder
    {
        IHttpClientBuilder HttpClientBuilder { get; }

        string Name { get; }
    }
}
