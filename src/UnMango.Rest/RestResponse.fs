namespace UnMango.Rest

open System.Net.Http

type RestResponse(response: HttpResponseMessage) =
    interface IRestResponse with
        member this.ResponseMessage = response
