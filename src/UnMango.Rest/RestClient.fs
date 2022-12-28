namespace UnMango.Rest

open System
open System.IO
open System.Net.Http
open UnMango.Rest.Serialization

type RestClient(client: HttpClient, serializers: ISerializerCollection) =
    let createRequest (r: IRestRequest) : HttpRequestMessage = new HttpRequestMessage(r.Method, r.Uri)

    interface IRestClient with
        member this.HttpClient = client

        member this.Serializers = serializers

        member this.PostAsync(uri: Uri, request, cancellationToken) =
            task {
                use stream = new MemoryStream()
                do! serializers.Default.SerializeAsync(stream, request, cancellationToken)
                use content = new StreamContent(stream)
                use! response = client.PostAsync(uri, content, cancellationToken)

                use! responseContent =
                    response
                        .EnsureSuccessStatusCode()
                        .Content.ReadAsStreamAsync()

                return! serializers.Default.DeserializeAsync(responseContent, cancellationToken)
            }

        member this.PostAsync(uri: string, request, cancellationToken) =
            let test = Util.createUri uri
            this.PostAsync(test, request, cancellationToken)

        member this.SendAsync(request, cancellationToken) =
            task {
                let httpRequest = createRequest request
                let! response = client.SendAsync(httpRequest, cancellationToken)
                return RestResponse(response) :> IRestResponse
            }
