using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using Xunit;

namespace UnMango.Rest.Tests
{
    [Trait("Category", "Unit")]
    public class RestRequestTests
    {
        private readonly Mock<IRestClient> _client = new Mock<IRestClient>();

        [Fact]
        public async Task Sandbox()
        {
            var temp = RestRequest.Create(new HttpClient());

            var test = await temp;
        }
    }
}
