module Pangram.Tests
 
open NUnit.Framework
open FileIO
open Pangram

[<Test>]
let ``Convert string of sentences to list``() = 
    let incoming = "Edit the Expression & Text to see matches. Roll over matches or the expression for details. Undo mistakes with cmd-z. Save Favorites & Share expressions with friends or the Community. Explore your results with Tools. A full Reference & Help is available in the Library, or watch the video Tutorial."
    let list = ["Edit the Expression & Text to see matches.";"Roll over matches or the expression for details."; "Undo mistakes with cmd-z."; "Save Favorites & Share expressions with friends or the Community."; "Explore your results with Tools."; "A full Reference & Help is available in the Library, or watch the video Tutorial."]
    Assert.AreEqual(list, Pangram.sentences incoming)

[<Test>]
let ``String to lowercase letter only set``() =
    let i = "HeL27&@lo00"
    let o = set['h';'e';'l';'l';'o']
    Assert.AreEqual(o, Pangram.Alphabet.explode i)

[<Test>]
let ``Set equality``() =
    let i = Pangram.Alphabet.explode "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
    let o = set['a'..'z']
    Assert.AreEqual(o, i)

[<Test>]
let ``Set inequality``() =
    let i = Pangram.Alphabet.explode "abhoisud"
    let o = set['a'..'z']
    Assert.AreNotSame(o, i)

[<Test>]
let ``Set equality even with random chars``() =
    let i = Pangram.Alphabet.explode "ABCDEFGHIJKLMNO7638&*62786187yS&*Dg78@198@873**@37PQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
    let o = set['a'..'z']
    Assert.AreEqual(o, i)

[<Test>]
let ``Pangram detection are same``() =
    let list = set["Edit the Expression & Text to see matches.";"Roll over matches or the expression for details."; "Undo mistakes with cmd-z."; "Save Favorites & Share expressions with friends or the Community."; "Explore your results with Tools."; "the quick brown fox jumps over the lazy dog."; "A full Reference & Help is available in the Library, or watch the video Tutorial."]
    let o = set["the quick brown fox jumps over the lazy dog."]
    Assert.AreEqual(o, Pangram.findPangrams list)

[<Test>]
let ``Multiple pangram detection``() =
    let list = set["Edit the Expression & Text to see matches."; "This Pangram contains four a’s, one b, two c’s, one d, thirty e’s, six f’s, five g’s, seven h’s, eleven i’s, one j, one k, two l’s, two m’s, eighteen n’s, fifteen o’s, two p’s, one q, five r’s, twenty-seven s’s, eighteen t’s, two u’s, seven v’s, eight w’s, two x’s, three y’s, & one z.";"Roll over matches or the expression for details."; "Undo mistakes with cmd-z."; "Save Favorites & Share expressions with friends or the Community."; "Explore your results with Tools."; "the quick brown fox jumps over the lazy dog."; "A full Reference & Help is available in the Library, or watch the video Tutorial."]
    let o = set["the quick brown fox jumps over the lazy dog."; "This Pangram contains four a’s, one b, two c’s, one d, thirty e’s, six f’s, five g’s, seven h’s, eleven i’s, one j, one k, two l’s, two m’s, eighteen n’s, fifteen o’s, two p’s, one q, five r’s, twenty-seven s’s, eighteen t’s, two u’s, seven v’s, eight w’s, two x’s, three y’s, & one z."]
    Assert.AreEqual(o, Pangram.findPangrams list)

[<Test>]
let ``Pangram detection fails``() =
    let list = set["Edit the Expression & Text to see matches."; "This Pangram contains four a’s, one b, two c’s, one d, thirty e’s, six f’s, five g’s, seven h’s, eleven i’s, one j, one k, two l’s, two m’s, eighteen n’s, fifteen o’s, two p’s, one q, five r’s, twenty-seven s’s, eighteen t’s, two u’s, seven v’s, eight w’s, two x’s, three y’s, & one z.";"Roll over matches or the expression for details."; "Undo mistakes with cmd-z."; "Save Favorites & Share expressions with friends or the Community."; "Explore your results with Tools."; "the quick brown fox jumps over the lazy dog."; "A full Reference & Help is available in the Library, or watch the video Tutorial."]
    let o = set["the quick brown fox jumps over the lazy dog."]
    Assert.AreNotEqual(o, Pangram.findPangrams list)

[<Test>]
let``Find in string``() =
    let i ="Lots of sentences. THat arent right. the quick brown fox jumps over the lazy dog. lalallala"
    let o = set["the quick brown fox jumps over the lazy dog."]
    Assert.AreEqual(o, Pangram.Find i)