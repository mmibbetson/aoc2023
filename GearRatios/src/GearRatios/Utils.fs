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
        |> Seq.collect id

    schematic

let partNumbers (schematic: Position seq) =
    