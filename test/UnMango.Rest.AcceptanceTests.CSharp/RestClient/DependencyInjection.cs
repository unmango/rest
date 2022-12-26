using Microsoft.Extensions.DependencyInjection;
using UnMango.Rest.DependencyInjection;

namespace UnMango.Rest.AcceptanceTests.CSharp.RestClient;

file record MyRequest;

file record MyResponse;

[Trait("Category", "Acceptance")]
public class DependencyInjection
{
    private readonly IServiceProvider _services = new ServiceCollection()
        .AddRestClient()
        .BuildServiceProvider();

    [Fact]
    public async Task PostAsync_HappyPath()
    {
        var request = new MyRequest();
        var client = _services.GetRequiredService<IRestClient>();

        var response = await client.PostAsync<MyRequest, MyResponse>("https://example.com", request, CancellationToken.None);
        
        Assert.NotNull(response);
    }
}
