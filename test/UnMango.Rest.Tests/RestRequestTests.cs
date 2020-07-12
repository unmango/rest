using System;
using System.Net.Http;
using Moq;
using Xunit;

namespace UnMango.Rest.Tests
{
    [Trait("Category", "Unit")]
    public class RestRequestTests
    {
        private readonly Mock<IRestClient> _client = new Mock<IRestClient>();
        
        [Fact]
        public void ClientCtor_InitializesQueryParams()
        {
            var request = new RestRequest(_client.Object);
            
            Assert.NotNull(request.QueryParameters);
            Assert.Empty(request.QueryParameters);
        }

        [Fact]
        public void ClientCtor_ThrowsWhenClientIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new RestRequest(null!));
        }

        [Fact]
        public void ClientMethodCtor_InitializesMethod()
        {
            var request = new RestRequest(_client.Object, HttpMethod.Get);
            
            Assert.NotNull(request.Method);
        }
        
        [Fact]
        public void ClientMethodCtor_InitializesQueryParams()
        {
            var request = new RestRequest(_client.Object, HttpMethod.Get);
            
            Assert.NotNull(request.QueryParameters);
            Assert.Empty(request.QueryParameters);
        }

        [Fact]
        public void ClientMethodCtor_ThrowsWhenClientIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new RestRequest(null!, HttpMethod.Get));
        }
    }
}
