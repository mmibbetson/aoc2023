open System
open System.IO

open GearRatios.Types
open GearRatios.Utils

let input = Environment.GetCommandLineArgs()[1] |> File.ReadAllLines

let schematic = createSchematic input

let firstAnswer = schematic |> partNumbers |> Seq.sum

printfn $"{firstAnswer}"