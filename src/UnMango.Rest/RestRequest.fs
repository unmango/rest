namespace UnMango.Rest

open System.Net.Http

type RestRequest<'B, 'R> =
    { Body: 'B option
      Client: IRestClient
      Method: HttpMethod option
      QueryParameters: Map<string, string> }

    member this.GetAwaiter() =
        this.Client.SendAsync(this).GetAwaiter()

    interface IRestRequest with
        member this.Client = this.Client
        member this.Method = this.Method |> Option.get
        member this.QueryParameters = this.QueryParameters
        member this.GetAwaiter() = this.GetAwaiter()

    static member Create(c: HttpClient) : IRestRequest =
        { Body = None
          Client = RestClient(c)
          Method = None
          QueryParameters = Map.empty }

module internal RestRequest =
    let unwrap (r: IRestRequest) =
        match r with
        | :? RestRequest<_, _> as req -> req
        | _ ->
            { Body = None
              Client = r.Client
              Method = Some r.Method
              QueryParameters = r.QueryParameters |> Util.toMap }
