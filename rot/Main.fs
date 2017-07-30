namespace Rot13
open Rot
open FileIO


module Main =
  [<EntryPoint>]
  let entry argv =
    if (argv.Length = 0) then
          nullArg("Please provide the route to a file on the system to process")
    else
      FileIO.Open argv.[0]
      |> List.map(fun line -> Rot.Encrypt.rotify(line) |> printfn("%s") )
      |> ignore

      0