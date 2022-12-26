namespace UnMango.Rest

open System.Net.Http

type RestClient(client: HttpClient) =
    let createRequest (r: IRestRequest) : HttpRequestMessage = failwith "todo"

    interface IRestClient with
        member this.HttpClient = client

        member this.SendAsync(request, cancellationToken) =
            task {
                let httpRequest = createRequest request
                let! response = client.SendAsync(httpRequest, cancellationToken)
                return RestResponse(response) :> IRestResponse
            }
