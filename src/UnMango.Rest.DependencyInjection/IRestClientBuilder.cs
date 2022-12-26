using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;

namespace UnMango.Rest.DependencyInjection;

[PublicAPI]
public interface IRestClientBuilder
{
    IHttpClientBuilder HttpClientBuilder { get; }
    
    string Name { get; }
    
    IServiceCollection Services { get; }
    
    static abstract IRestClientBuilder New(IHttpClientBuilder builder);
}
