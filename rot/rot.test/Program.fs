module Tests

open System
open NUnit.Framework
open Rot
open Main

[<Test>]
let ``Expand a string into a list with each character as an element``() =
    let zeroUSD = 0
    Assert.AreEqual(zeroUSD, 0)


[<Test>]
let ``Implode the created list into a string containing the characters in the list``() =
    let list = ['H';'e';'l';'l';'o']
    Assert.AreEqual("Hello", Rot.Alphabet.implode list)

[<Test>]
let ``Explode a string into a char list``() =
    let string = "Hello"
    let list = ['H';'e';'l';'l';'o']
    Assert.AreEqual(list, Rot.Alphabet.explode string)

[<Test>]
let ``Rot13 this string``() =
    let i = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
    let o = "NOPQRSTUVWXYZABCDEFGHIJKLMnopqrstuvwxyzabcdefghijklm"
    Assert.AreEqual(o, Rot.Encrypt.rotify(i))

[<Test>]
let ``Handle non text inputs``() =
    let i = "ABCD!FGHI-KLMNO4QRSTUV6XYZabcdefghijk-mnopqrs@uvwxyz"
    let o = "NOPQ!STUV-XYZAB4DEFGHI6KLMnopqrstuvwx-zabcdef@hijklm"
    Assert.AreEqual(o, Rot.Encrypt.rotify(i))

[<Test>]
let ``Handle non text shifting``() =
    let i = '@'
    let o = '@'
    Assert.AreEqual(o, Rot.Encrypt.shift(i))

[<Test>]
let ``Shift 13 characters allong alphabet``() =
    let i = 'A'
    let o = 'N'
    Assert.AreEqual(o, Rot.Encrypt.shift(i))

[<Test>]
let ``Shift 13 characters allong alphabet lowercase``() =
    let i = 'a'
    let o = 'n'
    Assert.AreEqual(o, Rot.Encrypt.shift(i))


[<Test>]
let ``Check that argument is provided``() =
    Assert.Throws(Main)