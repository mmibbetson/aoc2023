module CubeConundrum.Program

open System
open System.IO

open CubeConundrum.Types
open CubeConundrum.Utils

let input = Environment.GetCommandLineArgs()[1] |> File.ReadAllLines

let games = input |> Array.map constructGame

let validGameNumbers = Array.filter gameIsPossible games |> Array.map (_.Number)

let validGameTotal =
    Array.sum validGameNumbers
    |> sprintf "The sum of the ID's of all valid games: %A"

let powersOfAllSets =
    games
    |> Array.map gamePower
    |> Array.sum
    |> sprintf "The combined powers of all sets: %A"

Console.WriteLine powersOfAllSets
Console.WriteLine validGameTotal

exit 0
