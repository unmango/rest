using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Utf8Json;

namespace UnMango.Rest.Serialization
{
    /// <summary>
    /// JSON serializer implementation using Utf8Json.
    /// </summary>
    public class Utf8JsonSerializer : ISerializer
    {
        /// <inheritdoc />
        public ValueTask<T> DeserializeAsync<T>(Stream stream, CancellationToken cancellationToken = default)
        {
            return new(JsonSerializer.DeserializeAsync<T>(stream));
        }

        /// <inheritdoc />
        public ValueTask SerializeAsync<T>(T value, Stream stream, CancellationToken cancellationToken = default)
        {
            return new(JsonSerializer.SerializeAsync(stream, value));
        }
    }
}
