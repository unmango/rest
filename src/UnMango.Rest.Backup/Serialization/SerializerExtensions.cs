using System;
using System.IO;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

namespace UnMango.Rest.Serialization
{
    /// <summary>
    /// Extension methods for <see cref="ISerializer"/>.
    /// </summary>
    public static class SerializerExtensions
    {
        /// <summary>
        /// Deserializes the content from <paramref name="stream"/> as <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to deserialize as.</typeparam>
        /// <param name="serializer">The serializer to use.</param>
        /// <param name="stream">The content to deserialize.</param>
        /// <returns>The deserialized value.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="serializer"/> or <paramref name="stream"/> are null.
        /// </exception>
        public static T Deserialize<T>(this ISerializer serializer, Stream stream)
        {
            if (serializer == null) throw new ArgumentNullException(nameof(serializer));
            if (stream == null) throw new ArgumentNullException(nameof(stream));

            return serializer.DeserializeAsync<T>(stream).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Deserializes the content from <paramref name="reader"/> as <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to deserialize as.</typeparam>
        /// <param name="serializer">The serializer to use.</param>
        /// <param name="reader">The content to deserialize.</param>
        /// <param name="cancellationToken">Used to signal cancellation to running operations.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation containing the deserialized value.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="serializer"/> or <paramref name="reader"/> are null.
        /// </exception>
        public static ValueTask<T> DeserializeAsync<T>(
            this ISerializer serializer,
            PipeReader reader,
            CancellationToken cancellationToken = default)
        {
            if (serializer == null) throw new ArgumentNullException(nameof(serializer));
            if (reader == null) throw new ArgumentNullException(nameof(reader));

            using var stream = reader.AsStream();
            return serializer.DeserializeAsync<T>(stream, cancellationToken);
        }

        /// <summary>
        /// Serializes <paramref name="value"/> into <paramref name="stream"/>.
        /// </summary>
        /// <typeparam name="T">The type of the value to serialize.</typeparam>
        /// <param name="serializer">The serializer to use.</param>
        /// <param name="value">The value to serialize.</param>
        /// <param name="stream">The stream to serialize into.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="serializer"/> or <paramref name="stream"/> are null.
        /// </exception>
        public static void Serialize<T>(this ISerializer serializer, T value, Stream stream)
        {
            if (serializer == null) throw new ArgumentNullException(nameof(serializer));
            if (stream == null) throw new ArgumentNullException(nameof(stream));

            serializer.SerializeAsync(value, stream).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Serializes <paramref name="value"/> into a <see cref="MemoryStream"/>.
        /// </summary>
        /// <typeparam name="T">The type of the value to serialize.</typeparam>
        /// <param name="serializer">The serializer to use.</param>
        /// <param name="value">The value to serialize.</param>
        /// <returns>The value serialized as a <see cref="MemoryStream"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="serializer"/> is null.</exception>
        public static Stream Serialize<T>(this ISerializer serializer, T value)
        {
            if (serializer == null) throw new ArgumentNullException(nameof(serializer));

            var stream = new MemoryStream();
            serializer.Serialize(value, stream);
            return stream;
        }

        /// <summary>
        /// Serializes <paramref name="value"/> into a <see cref="MemoryStream"/>.
        /// </summary>
        /// <typeparam name="T">The type of the value to serialize.</typeparam>
        /// <param name="serializer">The serializer to use.</param>
        /// <param name="value">The value to serialize.</param>
        /// <param name="cancellationToken">Used to signal cancellation to running operations.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation, containing
        /// <paramref name="value"/> serialized as a <see cref="MemoryStream"/>
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="serializer"/> is null.</exception>
        public static async Task<Stream> SerializeAsync<T>(
            this ISerializer serializer,
            T value,
            CancellationToken cancellationToken = default)
        {
            if (serializer == null) throw new ArgumentNullException(nameof(serializer));

            var stream = new MemoryStream();
            await serializer.SerializeAsync(value, stream, cancellationToken);
            return stream;
        }

        /// <summary>
        /// Serializes <paramref name="value"/> into <paramref name="writer"/>.
        /// </summary>
        /// <typeparam name="T">The type of the value to serialize.</typeparam>
        /// <param name="serializer">The serializer to use.</param>
        /// <param name="value">The value to serialize.</param>
        /// <param name="writer">The <see cref="PipeWriter"/> to serialize into.</param>
        /// <param name="cancellationToken">Used to signal cancellation to running operations.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="serializer"/> or <paramref name="writer"/> are null.
        /// </exception>
        public static ValueTask SerializeAsync<T>(
            this ISerializer serializer,
            T value,
            PipeWriter writer,
            CancellationToken cancellationToken = default)
        {
            if (serializer == null) throw new ArgumentNullException(nameof(serializer));
            if (writer == null) throw new ArgumentNullException(nameof(writer));

            using var stream = writer.AsStream();
            return serializer.SerializeAsync(value, stream, cancellationToken);
        }

        /// <summary>
        /// Serializes <paramref name="value"/> an returns a <see cref="PipeReader"/>
        /// capable of reading the result.
        /// </summary>
        /// <typeparam name="T">The type of the value to serialize.</typeparam>
        /// <param name="serializer">The serializer to use.</param>
        /// <param name="value">The value to serialize.</param>
        /// <param name="cancellationToken">Used to signal cancellation to running operations.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation, containing
        /// a <see cref="PipeReader"/> capable of reading the serialized <paramref name="value"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="serializer"/> is null.</exception>
        public static async Task<PipeReader> SerializeToReaderAsync<T>(
            this ISerializer serializer,
            T value,
            CancellationToken cancellationToken = default)
        {
            if (serializer == null) throw new ArgumentNullException(nameof(serializer));

            var pipe = new Pipe();
            await serializer.SerializeAsync(value, pipe.Writer, cancellationToken);
            return pipe.Reader;
        }
    }
}
