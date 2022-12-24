namespace UnMango.Rest

open System
open System.Net.Http
open System.Threading

type RestRequest<'B, 'R> =
    { CancellationToken: CancellationToken option
      Body: 'B option
      Client: IRestClient
      Method: HttpMethod option
      QueryParameters: Map<string, string>
      Uri: Uri option }

    member this.GetAwaiter() =
        match this.CancellationToken with
        | Some token -> this.Client.SendAsync(this, token).GetAwaiter()
        | None -> this.Client.SendAsync(this).GetAwaiter()

    interface IRestRequest with
        member this.Client = this.Client
        member this.Method = this.Method |> Option.get
        member this.QueryParameters = this.QueryParameters
        member this.GetAwaiter() = this.GetAwaiter()

module RestRequest =
    let internal unwrap (r: IRestRequest) =
        match r with
        | :? RestRequest<_, _> as req -> req
        | _ ->
            { CancellationToken = None
              Body = None
              Client = r.Client
              Method = Some r.Method
              QueryParameters = r.QueryParameters |> Util.toMap
              Uri = None }

    let Create(c: HttpClient) : IRestRequest =
        { CancellationToken = None
          Body = None
          Client = RestClient(c)
          Method = None
          QueryParameters = Map.empty
          Uri = None }
