namespace UnMango.Rest

open System.Net.Http
open System.Runtime.CompilerServices
open System.Threading.Tasks

[<Extension>]
type HttpClientExtensions =
    [<Extension>]
    static member Get<'T>(c: HttpClient) = Task.CompletedTask 
