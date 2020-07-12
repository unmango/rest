using System;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Xunit;

namespace UnMango.Rest.Tests
{
    [Trait("Category", "Unit")]
    public class RestRequestExtensionsTests
    {
        private readonly Mock<IRestClient> _client = new Mock<IRestClient>();
        private readonly Mock<IRestRequest> _request = new Mock<IRestRequest>();

        public RestRequestExtensionsTests()
        {
            _request.SetupGet(x => x.Client).Returns(_client.Object);
        }

        [Fact]
        public async Task Execute_ExecutesClient()
        {
            await _request.Object.ExecuteAsync();

            _client.Verify(x => x.SendAsync(_request.Object, It.IsAny<CancellationToken>()));
        }

        [Fact]
        public Task Execute_ThrowsWhenRequestIsNull()
        {
            return Assert.ThrowsAsync<ArgumentNullException>(() => ((IRestRequest)null!).ExecuteAsync());
        }
    }
}
