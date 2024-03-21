open System
open System.IO


type GameCard =
    { Id: int
      WinningNumbers: int array
      CardNumbers: int array }


let constructGameCard (line: string) =
    let destructuredLine = line.Split(':', '|')

    let getNumberArray (str: String) =
        str.Split(' ', StringSplitOptions.RemoveEmptyEntries) |> Array.map int

    let id = destructuredLine[0] |> String.filter Char.IsDigit |> int
    let winningNumbers = destructuredLine[1] |> getNumberArray
    let cardNumbers = destructuredLine[2] |> getNumberArray

    { Id = id
      WinningNumbers = winningNumbers
      CardNumbers = cardNumbers }


let cardScore gameCard =
    gameCard.CardNumbers
    |> Array.filter (fun num -> Array.contains num gameCard.WinningNumbers)
    |> Array.fold (fun acc _ -> if acc = 0 then 1 else acc * 2) 0


let numberOfMatches gameCard =
    gameCard.CardNumbers
    |> Array.filter (fun num -> Array.contains num gameCard.WinningNumbers)
    |> Array.length


let rec numberGenerated (arr: int array) idx =
    match arr[idx] with
    | 0 -> 1
    | matches ->
        1
        + Array.reduce (fun acc offset -> acc + numberGenerated arr (idx + offset)) [| 0..matches |]
//  | matches -> 1 + ([| for offset in 1..matches -> numberGenerated (idx + offset) arr |] |> Array.sum)
//  ^ AI generated alternative equivalent using an array comprehension


let gameCards = Environment.GetCommandLineArgs()[1] |> File.ReadAllLines |> Array.map constructGameCard
let matchList = gameCards |> Array.map numberOfMatches

let firstAnswer = gameCards |> Array.map cardScore |> Array.sum
let secondAnswer = matchList |> Array.mapi (fun idx _ -> numberGenerated matchList idx) |> Array.sum

printfn $"First Answer: %d{firstAnswer}"
printfn $"Second Answer: %d{secondAnswer}"
