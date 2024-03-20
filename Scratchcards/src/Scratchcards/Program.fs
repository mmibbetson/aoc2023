open System
open System.IO


type GameCard =
    { Id: int
      WinningNumbers: int array
      CardNumbers: int array }


let constructGameCard (line: string) =
    let destructuredLine = line.Split([| ':'; '|' |])
    let id = destructuredLine[0] |> String.filter Char.IsDigit |> int

    let winningNumbers =
        destructuredLine[1]
        |> (_.Split(' ', StringSplitOptions.RemoveEmptyEntries))
        |> Array.map int

    let cardNumbers =
        destructuredLine[2]
        |> (_.Split(' ', StringSplitOptions.RemoveEmptyEntries))
        |> Array.map int

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

// take in an int array and for each elem keep track of how many clones they generate. need id's or smth
let rec clone count 

let input = Environment.GetCommandLineArgs()[1] |> File.ReadAllLines

input
|> Array.map constructGameCard
|> Array.map cardScore
|> Array.sum
|> fun n -> printfn $"First Answer: {n}"

// get the game cards
// evaluate how many matches each card has
// apply those matches against the subsequent cards to mult their mults
// sum the number of items in the end

input
|> Array.map constructGameCard
|> Array.map numberOfMatches
|> 