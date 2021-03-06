﻿// =================================
// Exercise: ConstrainedTypes
//
// Given the definition of the constrained types below,
// write functions that implement the constructor and property getter.
// =================================


open System

// a useful helper function
let notImplemented() = failwith "not implemented"

//----------------------------------------------------------
// Exercise: Create a `NonZeroInteger`  type that can only contain non-zero integers
//----------------------------------------------------------

module ConstrainedTypes =

    /// Must be <> 0
    type NonZeroInteger = private NonZeroInteger of int

    module NonZeroInteger =

        // TODO: Implement public constructor
        let create i =
            if i = 0 then
                None
            else
                Some (NonZeroInteger i)

        // TODO: Return the value
        let value (NonZeroInteger i) = i

// --------------------------------
// test NonZeroInteger
// --------------------------------

open ConstrainedTypes

// test
// NonZeroInteger 1 // uncomment for error
let nonZeroOpt0 = NonZeroInteger.create 0
let nonZeroOpt1 = NonZeroInteger.create 1



//----------------------------------------------------------
//  Exercise: Create a `ZipCode`  type that can only contain 5 digit chars
//----------------------------------------------------------

module ConstrainedTypes2 =

    /// Must be 5 chars, all digits
    type ZipCode = private ZipCode of string

    module ZipCode =

        /// TODO Public constructor
        let create (s:string) =

            // local helper function
            let is5Digits (s:string) =
                let isAllDigits = s |> Seq.forall Char.IsDigit
                (s.Length = 5) && isAllDigits

            // construct the ZipCode
            if is5Digits s then
                Some (ZipCode s)
            else
                None

        /// TODO Return the value
        let value (ZipCode s) = s

// --------------------------------
// test ZipCode
// --------------------------------

open ConstrainedTypes2

let zip1Option = ZipCode.create "12345"
let zip1 = zip1Option |> Option.get  // dont do this except for testing!

let zip2Option = ZipCode.create "abc"

let zip3Option = ZipCode.create "123456"
