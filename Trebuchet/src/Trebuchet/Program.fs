module Trebuchet.Program

open System

open Trebuchet.Utils

input
|> Array.map deriveCalibrationNumbers
|> Array.sum
|> Console.WriteLine
