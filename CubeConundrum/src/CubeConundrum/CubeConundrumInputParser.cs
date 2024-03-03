namespace CubeConundrum;

public class CubeConundrumInputParser
{
    public IEnumerable<Game> Parse(string[] input)
    {
        var games = input.Select(line =>
        {
            var gameAndSets = line.Split(':');
            var (gamePrefix, setsSuffix) = (gameAndSets[0], gameAndSets[1]);

            var gameNumber = int.Parse(gamePrefix.Where(char.IsDigit).ToArray());
            var sets = ConstructSets(setsSuffix);

            var game = new Game { Number = gameNumber, Sets = sets };

            return game;
        });

        return games;
    }

    private IEnumerable<Set> ConstructSets(string setsSuffix)
    {
        var splitSets = setsSuffix.Split(';');

        var setStructs = splitSets.Select(set =>
        {
            var red = GetColourCount("red", set);
            var green = GetColourCount("green", set);
            var blue = GetColourCount("blue", set);


            return new Set { Red = red, Green = green, Blue = blue };
        });

        return setStructs;
    }

    private int GetColourCount(string colour, string set)
    {
        var splitColours = set.Split(',');
        var setHasColour = splitColours.Any(element => element.Contains(colour));

        if (!setHasColour)
        {
            return 0;
        }

        var colourElement = splitColours.First(element => element.Contains(colour));
        var colourCount = int.Parse(colourElement.Where(char.IsDigit).ToArray());

        return colourCount;
    }
}