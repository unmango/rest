module UnMango.Rest.Rest

open System.Net.Http

let body b r =
    { r with Body = Some b }

let query k v r =
    { r with QueryParameters = Map.add k v r.QueryParameters }

let method m r =
    { r with Method = Some m }

let delete r = method HttpMethod.Delete r

let get r = method HttpMethod.Get r

let patch r = method HttpMethod.Patch r

let post r = method HttpMethod.Post r

let put r = method HttpMethod.Put r
