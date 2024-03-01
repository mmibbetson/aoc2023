module CubeConundrum.Utils

open System

open CubeConundrum.Types

let getCount (colourName: string) (splitColours: string array) =
    let colourTerm =
        splitColours
        |> Array.filter (fun (colour: string) -> colour.Contains(colourName))

    match Array.length colourTerm with
    | 0 -> 0
    | _ ->
        colourTerm
        |> Array.head
        |> (_.ToCharArray())
        |> Array.filter Char.IsDigit
        |> Array.map string
        |> String.concat ""
        |> int

let constructSet (set: string) =
    let splitColours = set.Split(",")

    let redCount = getCount "red" splitColours
    let greenCount = getCount "green" splitColours
    let blueCount = getCount "blue" splitColours

    let gameSet =
        { Red = redCount
          Green = greenCount
          Blue = blueCount }

    gameSet

let getSets (line: string) =
    let inputSetPartition = line.Split(":")[1] in
    
    inputSetPartition.Split(";") |> Array.map constructSet

let constructGame (line: string) =
    let gamePrefix = line.Split(":")[0] in
    let gameNumberChars = gamePrefix.ToCharArray() |> Array.filter Char.IsDigit
    let gameNumber = String.Concat("", gameNumberChars) |> int

    let sets = getSets line

    let game = { Number = gameNumber; Sets = sets }

    game

let gameIsPossible (game: Game) =
    let sets = game.Sets in

    let invalidRed =
        sets |> Array.map (_.Red) |> Array.exists (fun count -> count > 12)

    let invalidGreen =
        sets |> Array.map (_.Green) |> Array.exists (fun count -> count > 13)

    let invalidBlue =
        sets |> Array.map (_.Blue) |> Array.exists (fun count -> count > 14)

    match invalidRed, invalidGreen, invalidBlue with
    | false, false, false -> true
    | _ -> false

let gamePower (game: Game) =
    let sets = game.Sets in
    
    let requiredRed =
        sets |> Array.map (_.Red) |> Array.max
        
    let requiredGreen =
        sets |> Array.map (_.Green) |> Array.max
        
    let requiredBlue =
        sets |> Array.map (_.Blue) |> Array.max
        
    requiredRed * requiredGreen * requiredBlue
