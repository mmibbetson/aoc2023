module Trebuchet.Utils

open System

open System.IO

open Trebuchet.Parser

let input =
    let args = Environment.GetCommandLineArgs() in

    match args |> Seq.length with
    | 2 -> File.ReadAllLines(args[1])
    | _ -> ArgumentException("Please provide an input file") |> raise

let deriveCalibrationNumbers line =
    line
    |> transformNumberWords
    |> numbersOnly
    |> firstAndLast
    |> int
