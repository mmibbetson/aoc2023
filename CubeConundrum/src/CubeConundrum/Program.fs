module CubeConundrum

open System
open System.IO

let inputDir = "./inputs/example1.txt"

inputDir
|> File.ReadAllLines
|> Console.Write

exit 0