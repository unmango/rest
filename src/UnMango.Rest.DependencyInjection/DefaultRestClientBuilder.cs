using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;

namespace UnMango.Rest.DependencyInjection;

[PublicAPI]
public class DefaultRestClientBuilder : IRestClientBuilder
{
    public DefaultRestClientBuilder(IHttpClientBuilder httpClientBuilder) => HttpClientBuilder = httpClientBuilder;

    public IHttpClientBuilder HttpClientBuilder { get; }

    public string Name => HttpClientBuilder.Name;

    public IServiceCollection Services => HttpClientBuilder.Services;

    public static IRestClientBuilder New(IHttpClientBuilder builder) => new DefaultRestClientBuilder(builder);
}
