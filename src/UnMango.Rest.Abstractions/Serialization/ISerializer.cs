using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace UnMango.Rest.Serialization
{
    /// <summary>
    /// Abstraction for seializing to and from <see cref="Stream"/>s.
    /// </summary>
    public interface ISerializer
    {
        /// <summary>
        /// Deserializes the content from <paramref name="stream"/> as <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to deserialize as.</typeparam>
        /// <param name="stream">The content to deserialize.</param>
        /// <param name="cancellationToken">Used to signal cancellation to running operations.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation containing the deserialized value.
        /// </returns>
        Task<T> DeserializeAsync<T>(Stream stream, CancellationToken cancellationToken = default);

        /// <summary>
        /// Serializes <paramref name="value"/> into <paramref name="stream"/>.
        /// </summary>
        /// <typeparam name="T">The type of the value to serialize.</typeparam>
        /// <param name="value">The value to serialize.</param>
        /// <param name="stream">The stream to serialize into.</param>
        /// <param name="cancellationToken">Used to signal cancellation to running operations.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task SerializeAsync<T>(T value, Stream stream, CancellationToken cancellationToken = default);
    }
}
