open FileIO
open Pangram

[<EntryPoint>]
let main argv = 
    if (argv.Length = 0) then
          printfn("Please provide the route to a file on the system to process")
          1 //No file found so return an error exit code
    else
      let foundPangrams = FileIO.Open argv.[0] |> Pangram.Find
      let numberFound = foundPangrams |> Seq.length


      let printFound n = 
          if (n = 0) then
            printfn "No pangrams found in %s" argv.[0]
            exit 0 //exit the program
          else if (n = 1) then
            printfn "Found 1 pangram"
          else 
            printfn "Found %i pangrams" n

      printFound numberFound

      //List the found pangrams to stdout
      let showPangrams found =
        found
        |> List.ofSeq
        |> List.map(fun line -> printfn "%s\n" line )
        |> ignore


      showPangrams foundPangrams

      0

