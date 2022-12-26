using JetBrains.Annotations;

namespace UnMango.Rest;

[PublicAPI]
public interface IRestResponse
{
    HttpResponseMessage ResponseMessage { get; }
}
