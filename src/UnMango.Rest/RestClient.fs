namespace UnMango.Rest

open System.Net.Http

type RestClient(client: HttpClient) =
    interface IRestClient with
        member this.SendAsync(request, cancellationToken) = failwith "todo"
        member this.HttpClient = client
