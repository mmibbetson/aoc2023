module CubeConundrum.Utils

open System

open CubeConundrum.Types

let stringDigitsOnly (s: string) =
    s
    |> (_.ToCharArray())
    |> Array.filter Char.IsDigit
    |> Array.map string
    |> String.concat ""

let getCount (colourName: string) (splitColours: string array) =
    let colourTerm =
        splitColours |> Array.filter (fun (colour: string) -> colour.Contains(colourName))

    match Array.length colourTerm with
    | 0 -> 0
    | _ ->
        colourTerm
        |> Array.head
        |> stringDigitsOnly
        |> int

let constructSet (set: string) =
    let splitColours = set.Split(",") in

    let redCount = getCount "red" splitColours
    let greenCount = getCount "green" splitColours
    let blueCount = getCount "blue" splitColours

    { Red = redCount; Green = greenCount; Blue = blueCount }

let getSets (line: string) =
    let setPartition = line.Split(":")[1] in

    setPartition.Split(";") |> Array.map constructSet

let constructGame (line: string) =
    let numberPartition = line.Split(":")[0] in
    let numberChars = numberPartition.ToCharArray() |> Array.filter Char.IsDigit in

    let number = String.Concat("", numberChars) |> int
    let sets = getSets line

    { Number = number; Sets = sets }

let gameIsPossible (game: Game) =
    let invalidRed =
        game.Sets |> Array.map (_.Red) |> Array.exists (fun count -> count > 12)    // Magic literal
    let invalidGreen =
        game.Sets |> Array.map (_.Green) |> Array.exists (fun count -> count > 13)
    let invalidBlue =
        game.Sets |> Array.map (_.Blue) |> Array.exists (fun count -> count > 14)

    match invalidRed, invalidGreen, invalidBlue with
    | false, false, false -> true
    | _ -> false

let gamePower (game: Game) =
    let requiredRed = game.Sets |> Array.map (_.Red) |> Array.max
    let requiredGreen = game.Sets |> Array.map (_.Green) |> Array.max
    let requiredBlue = game.Sets |> Array.map (_.Blue) |> Array.max

    requiredRed * requiredGreen * requiredBlue
