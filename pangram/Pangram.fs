module Pangram

open System
module Alphabet =

    let onlyLetters = fun l -> System.Char.IsLetter(l)
    
    let allLower = fun l -> System.Char.ToLower(l)

    let explode (s:string) =
        set[for char in s -> char]
        |> Set.filter onlyLetters
        |> Set.map allLower



open System.Text.RegularExpressions

let matchToString (m : Match) = m.Value

let sentences (s:string) =
    //Sentence regex
    let re = new Regex("[^.!?\s][^.!?]*(?:[.!?](?!['\"]?\s|$)[^.!?]*)*[.!?]?['\"]?(?=\s|$)")
    re.Matches(s)
    |> Seq.cast
    |> Seq.map matchToString

let alphabet = set['a' .. 'z']
let isPangram = 
    fun s -> alphabet.Equals( Alphabet.explode s )

let findPangrams ls =
    ls |> Seq.filter isPangram

let Find (s:string) =
    s |> sentences |> findPangrams