module Tests

open System
open NUnit.Framework


[<Test>]
let MoneyIsZero() =
    let zeroUSD = 0
    Assert.That(zeroUSD.IsZero)