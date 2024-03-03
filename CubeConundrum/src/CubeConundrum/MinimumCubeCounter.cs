namespace CubeConundrum;

public static class MinimumCubeCounter
{
    public static int FindPower(Game game)
    {
        var highestRed = 0;
        var highestGreen = 0;
        var highestBlue = 0;

        foreach (var set in game.Sets)
        {
            if (set.Red > highestRed) highestRed = set.Red;
            if (set.Green > highestGreen) highestGreen = set.Green;
            if (set.Blue > highestBlue) highestBlue = set.Blue;
        }

        return highestRed * highestGreen * highestBlue;
    }
}