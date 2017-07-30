module Rot


module Alphabet =

    let explode (s:string) =
        [for char in s -> char]

    //Take exploded string
    let implode (xs:char list) =
        let sb = System.Text.StringBuilder(xs.Length)
        xs |> List.iter (sb.Append >> ignore)
        sb.ToString()

module Encrypt =

    let az = "abcdefghijklmnopqrstuvwxyz"
    let azList = Alphabet.explode az

    let isUpper (c:char) =
        System.Char.IsUpper c

    let toUpper (c:char) =
        System.Char.ToUpper

    




[<EntryPoint>]
let main argv = 
    printfn "%A" Encrypt.az
    0 // return an integer exit code

    