module internal UnMango.Rest.Util

open System
open System.Collections.Generic

let toMap<'a, 'b when 'a: comparison> =
    Seq.map<KeyValuePair<'a, 'b>, 'a * 'b> (|KeyValue|) >> Map.ofSeq

let inline createUri u = Uri(u, UriKind.RelativeOrAbsolute)
