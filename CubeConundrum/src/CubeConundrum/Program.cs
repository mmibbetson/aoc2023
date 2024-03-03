using CubeConundrum;

var inputDirectory = args.First();
var input = File.ReadAllLines(inputDirectory);

var parser = new CubeConundrumInputParser();
var gameStructs = parser.Parse(input);

var validGames = gameStructs.Where(game =>
{
    var inValidRedCount = game.Sets.Any(set => set.Red > 12);
    var inValidGreenCount = game.Sets.Any(set => set.Green > 13);
    var inValidBlueCount = game.Sets.Any(set => set.Blue > 14);

    return (!inValidRedCount && !inValidGreenCount && !inValidBlueCount);
});

var validGameNumbers = validGames.Select(game => game.Number);
var allGamesMinimumCubePower = gameStructs.Select(MinimumCubeCounter.FindPower);

Console.WriteLine($"Sum of Valid Game Numbers: {validGameNumbers.Sum()}");
Console.WriteLine($"Sum of All Game Minimum Cube Powers: {allGamesMinimumCubePower.Sum()}");