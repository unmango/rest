namespace UnMango.Rest.Serialization

open UnMango.Rest

type DefaultSerializerCollection(?defaultSerializer: ISerializer) =
    let serializers = Map.empty<SerializerKey, ISerializer>

    let defaultSerializer =
        defaultSerializer |> Option.defaultValue (SystemTextJsonSerializer())

    interface ISerializerCollection with
        member this.Default = defaultSerializer

        member this.Get(key) =
            serializers |> Map.tryFind key |> Option.defaultValue defaultSerializer
