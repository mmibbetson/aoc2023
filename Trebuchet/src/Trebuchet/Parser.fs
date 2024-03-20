module Trebuchet.Parser

open System

let numberWords =
    [|
       ("one", "o1e")
       ("two", "t2o")
       ("three", "t3e")
       ("four", "4")
       ("five", "5e")
       ("six", "6")
       ("seven", "7n")
       ("eight", "e8t")
       ("nine", "9e")
    |]

let transformNumberWords (input: string) =
    // compiler struggles with  type inference, making fold equivalent cluttered:
    // Array.fold (fun (acc: string) (key, value) -> acc.Replace((key: string), (value: string))) input numberWords

    let mutable output = input

    for key, value in numberWords do
        output <- output.Replace(key, value)

    output

let numbersOnly = String.filter Char.IsDigit

let firstAndLast (line: string) =
    let firstChar = line.[0]
    let lastChar = line.[line.Length - 1]
    
    $"{firstChar}{lastChar}"
