namespace UnMango.Rest

type RestClient() =
    interface IRestClient with
        member this.SendAsync(request, cancellationToken) = failwith "todo"
        member this.HttpClient = failwith "todo"
