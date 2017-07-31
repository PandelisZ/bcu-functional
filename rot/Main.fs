namespace Rot13
open Rot
open FileIO


module Main =
  [<EntryPoint>]
  let entry argv =
    if (argv.Length = 0) then
          printfn("Please provide the route to a file on the system to process")
          1 //No file found so return an error exit code
    else
      FileIO.Open argv.[0]
      |> List.map(fun line -> Rot.Encrypt.rotify(line) |> printfn("%s") )
      |> ignore

      0