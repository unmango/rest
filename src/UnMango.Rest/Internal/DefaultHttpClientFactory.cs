using System.Net.Http;

namespace UnMango.Rest.Internal
{
    internal class DefaultHttpClientFactory : IHttpClientFactory
    {
        public HttpClient CreateClient(string name)
        {
            // As dumb as we can get rn
            return new HttpClient();
        }
    }
}
