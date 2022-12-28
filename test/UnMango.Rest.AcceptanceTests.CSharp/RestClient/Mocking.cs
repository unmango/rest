namespace UnMango.Rest.AcceptanceTests.CSharp.RestClient;

file record MyRequest;

file record MyResponse;

[Trait("Category", "Acceptance")]
public class Mocking
{
    private readonly Mock<IRestClient> _client = new();

    [Fact]
    public async Task PostAsync_StringHappyPath()
    {
        var request = new MyRequest();
        _client.Setup(x => x.PostAsync<MyRequest, MyResponse>(It.IsAny<Uri>(), request, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new MyResponse());

        var response = await _client.Object.PostAsync<MyRequest, MyResponse>(
            "https://example.com",
            request,
            CancellationToken.None);
        
        Assert.NotNull(response);
    }
}
