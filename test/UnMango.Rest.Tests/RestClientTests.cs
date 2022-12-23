using System;
using System.Net.Http;
using Moq;
using UnMango.Rest.Serialization;
using Xunit;

namespace UnMango.Rest.Tests
{
    [Trait("Category", "Unit")]
    public class RestClientTests
    {
        [Fact]
        public void Create_CreatesDefaultRestClient()
        {
            var httpClient = new HttpClient();

            var client = RestClient.Create(httpClient);
            
            Assert.NotNull(client);
            Assert.Same(httpClient, client.HttpClient);
        }

        [Fact]
        public void Create_ThrowsWhenHttpClientIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => RestClient.Create(null!));
        }
    }
}
