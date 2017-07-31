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
    //Helpers
    let isUpper (c:char) =
        System.Char.IsUpper c

    let toLower (c:char) =
        System.Char.ToLower c

    let toUpper (c:char) =
        System.Char.ToUpper c

    //Shift allong the alphabet
    let rec shift (c:char) =
     if(System.Char.IsLetter c) then
         let num = int(c) - int('A')
         let offsetNum = (num+13)%26
         if(isUpper c) then
             char(offsetNum + int('A'))
         else
             toUpper(c)
             |> shift
             |> toLower
     else
         c

    //Apply Rot13 to string
    let rotify(str:string) =
        Alphabet.explode(str)
        |> List.map (fun c -> shift(c)) 
        |> Alphabet.implode