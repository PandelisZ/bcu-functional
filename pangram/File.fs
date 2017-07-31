module FileIO

open System 
open System.IO

let Open(path:string) =
    match File.Exists(path) with
    | true -> 
        File.ReadAllText(path)
    | _ -> invalidArg "file" "The file specified does not exist"

