using JetBrains.Annotations;

namespace UnMango.Rest.Serialization;

[PublicAPI]
public readonly struct SerializerKey : IComparable
{
    public readonly HttpMethod Method;
    public readonly Uri Uri;

    public SerializerKey(HttpMethod method, Uri uri)
        => (Method, Uri) = (method, uri);

    public int CompareTo(object obj)
        => obj is SerializerKey other
           && Method == other.Method
           && Uri == other.Uri
            ? 0
            : -1;
}
