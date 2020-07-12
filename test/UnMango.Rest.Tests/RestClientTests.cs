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
        private readonly Mock<ISerializerCollection> _serializers = new Mock<ISerializerCollection>();
        
        [Fact]
        public void Create_CreatesDefaultRestClient()
        {
            var httpClient = new HttpClient();

            var client = RestClient.Create(httpClient, _serializers.Object);
            
            Assert.NotNull(client);
            Assert.Same(httpClient, client.HttpClient);
            Assert.NotNull(client.Serializers);
            Assert.Same(_serializers.Object, client.Serializers);
        }

        [Fact]
        public void Create_ThrowsWhenHttpClientIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => RestClient.Create(null!, _serializers.Object));
        }

        [Fact]
        public void Create_UsesSerializerCollectionInstanceWhenNotProvided()
        {
            var httpClient = new HttpClient();

            var client = RestClient.Create(httpClient);
            
            Assert.NotNull(client.Serializers);
            Assert.Same(SerializerCollection.Instance, client.Serializers);
        }
    }
}
