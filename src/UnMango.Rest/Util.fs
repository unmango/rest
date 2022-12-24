module internal UnMango.Rest.Util

open System.Collections.Generic

let toMap<'a, 'b when 'a: comparison> =
    Seq.map<KeyValuePair<'a, 'b>, 'a * 'b> (|KeyValue|) >> Map.ofSeq
