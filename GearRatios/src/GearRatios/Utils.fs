module GearRatios.Utils

open GearRatios.Types

let createSchematic (input: string array) =
    let asChars = input |> Seq.map _.ToCharArray()

    let schematic =
        asChars
        |> Seq.mapi (fun row columns ->
            columns
            |> Seq.mapi (fun column character ->
                let coordinates = (row, column) in

                { Coordinates = coordinates
                  Character = character }))
        |> Seq.concat

    schematic

let partNumbers (schematic: Position seq) =
    schematic
    |> Seq.fold (fun (state: int seq) position ->
        match position.Character with
        | '.' | '0' | '1' | '2' | '3' | '4' | '5' | '6' | '7' | '8' | '9' -> state
        | _ -> position |> adjacentNumbers schematic |> Seq.append state) Seq.empty
    
let adjacentCoordinates (schematic: Position seq) (coordinates: int * int) =
    // get 8 adj coords
    
let adjacentNumbers (schematic: Position seq) (position: Position): int seq =
    let adjacentPositions =
        schematic
        |> Seq.filter (fun pos -> adjacentCoordinates schematic position.Coordinates |> Seq.contains)