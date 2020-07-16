using System;
using System.Collections.Generic;
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

        [Fact]
        public void ClientMethodParamCtor_InitializesQueryParams()
        {
            // Arrange
            const string key = "key", value = "value";
            var query = new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>(key, value) };

            // Act
            var request = new RestRequest(_client.Object, HttpMethod.Get, query);

            // Assert
            Assert.NotNull(request.QueryParameters);
            Assert.Contains(
                request.QueryParameters,
                x => x is { Key: key, Value: value });
        }

        [Fact]
        public void ClientMethodParamCtor_InitializesMethod()
        {
            var request = new RestRequest(_client.Object, HttpMethod.Get, new Dictionary<string, string>());

            Assert.NotNull(request.Method);
        }

        [Fact]
        public void ClientMethodParamCtor_ThrowsWhenClientIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new RestRequest(null!, HttpMethod.Get, new Dictionary<string, string>()));
        }

        [Fact]
        public void ClientMethodParamCtor_ThrowsWhenParamsAreNull()
        {
            Assert.Throws<ArgumentNullException>(() => new RestRequest(_client.Object, HttpMethod.Get, null!));
        }
    }
}
