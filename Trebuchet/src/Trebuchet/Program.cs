using Trebuchet;

var inputDirectory = args.First();

var input = File.ReadAllLines(inputDirectory);

var partOneCalibrationValues = CalibrationValueParser.Parse(input, CalibrationValueParseOptions.None);
var partOneAnswer = partOneCalibrationValues.Sum();

var partTwoCalibrationValues = CalibrationValueParser.Parse(input, CalibrationValueParseOptions.ConvertNumberWords);
var partTwoAnswer = partTwoCalibrationValues.Sum();

Console.WriteLine($"Part One: {partOneAnswer}");
Console.WriteLine($"Part Two: {partTwoAnswer}");