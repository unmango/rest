namespace UnMango.Rest

open System.Net.Http

type RestRequest =
    { Client: IRestClient
      Method: HttpMethod
      QueryParameters: Map<string, string> }

    interface IRestRequest with
        member this.Client = this.Client
        member this.Method = this.Method
        member this.QueryParameters = this.QueryParameters
