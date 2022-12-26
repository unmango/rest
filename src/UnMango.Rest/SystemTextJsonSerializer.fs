namespace UnMango.Rest

open System.Text.Json
open UnMango.Rest.Serialization

type SystemTextJsonSerializer(?options: JsonSerializerOptions) =
    let options = options |> Option.defaultValue JsonSerializerOptions.Default

    interface ISerializer with
        member this.DeserializeAsync(stream, cancellationToken) =
            JsonSerializer.DeserializeAsync(stream, options, cancellationToken)

        member this.SerializeAsync(stream, value, cancellationToken) =
            JsonSerializer.SerializeAsync(stream, value, options, cancellationToken)
