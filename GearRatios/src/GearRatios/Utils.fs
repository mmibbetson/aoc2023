module GearRatios.Utils


open System


let createSchematic lines =
    let generatePoints =
        Seq.mapi (fun rowIdx row -> row |> Seq.mapi (fun colIdx character -> ((rowIdx, colIdx), character)))

    lines |> generatePoints |> Seq.concat |> Map.ofSeq


let adjacentCoordinates (row, column) =
    [| (row - 1, column - 1)
       (row - 1, column)
       (row - 1, column + 1)
       (row, column - 1)
       (row, column + 1)
       (row + 1, column - 1)
       (row + 1, column)
       (row + 1, column + 1) |]


let rec scanLeft schematic (row, column) =
    let leftCharacterKey = (row, column - 1) in

    match Map.tryFind leftCharacterKey schematic with
    | Some character ->
        match Char.IsDigit character with
        | true -> scanLeft schematic leftCharacterKey + string character
        | false -> ""
    | None -> ""


let rec scanRight schematic (row, column) =
    let rightCharacterKey = (row, column + 1) in

    match Map.tryFind rightCharacterKey schematic with
    | Some character ->
        match Char.IsDigit character with
        | true -> string character + scanRight schematic rightCharacterKey
        | false -> ""
    | None -> ""


let adjacentNumbers schematic symbolPosition =
    let adjacentNumberPositions =
        symbolPosition
        |> adjacentCoordinates
        |> Seq.filter (fun adjacentPosition ->
            match Map.tryFind adjacentPosition schematic with
            | Some position -> Char.IsDigit position
            | None -> false) in

    adjacentNumberPositions
    |> Seq.map (fun adjacentPosition ->
        let leftPortion = scanLeft schematic adjacentPosition
        let middlePortion = schematic.Item adjacentPosition |> string
        let rightPortion = scanRight schematic adjacentPosition

        leftPortion + middlePortion + rightPortion)
    |> Seq.map int
    |> Seq.distinct


let partNumbers schematic =
    schematic
    |> Map.filter (fun _ value -> not (Char.IsDigit value) && not (value = '.'))
    |> Map.fold (fun acc key _ -> key |> adjacentNumbers schematic |> Seq.append acc) Seq.empty

let gearRatios schematic =
    schematic
    |> Map.filter (fun key value -> value = '*' && (key |> adjacentNumbers schematic |> Seq.length) = 2)
    |> Map.fold
        (fun acc key _ ->
            key
            |> adjacentNumbers schematic
            |> Seq.reduce (*)
            |> Seq.singleton
            |> Seq.append acc)
        Seq.empty
