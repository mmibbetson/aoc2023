namespace Trebuchet;

public static class CalibrationValueParser
{
    private static readonly Dictionary<string, string> NumberWords = new()
    {
        {"zero", "0o"},
        {"one", "o1e"},
        {"two", "t2o"},
        {"three", "t3e"},
        {"four", "4"},
        {"five", "5e"},
        {"six", "6"},
        {"seven", "7n"},
        {"eight", "e8t"},
        {"nine", "9e"}
    };
    
    public static IEnumerable<int> Parse(IEnumerable<string> input, CalibrationValueParseOptions options)
    {
        if (options == CalibrationValueParseOptions.ConvertNumberWords)
        {
            foreach (var (key, value) in NumberWords)
            {
                input = input.Select(line => line.Replace(key, value));
            }
        }
        
        var joinedDigits =
            input
                .Select(line => line.Where(char.IsDigit))
                .Select(line => string.Join("", new[] { line.First(), line.Last() }))
                .Select(int.Parse);

        return joinedDigits;
    }
}