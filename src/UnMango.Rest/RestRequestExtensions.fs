namespace UnMango.Rest

open System.Runtime.CompilerServices

[<Extension>]
type RestRequestExtensions =
    [<Extension>]
    static member Get r =
        r |> RestRequest.unwrap |> Rest.get :> IRestRequest
