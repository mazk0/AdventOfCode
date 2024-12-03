using System.Text.RegularExpressions;

namespace AoC2024.Three;

public static partial class ThreeOne
{
    public static int Run(string dataFilepath)
    {
        var maxValue = 0;
        var corruptData = File.ReadAllText(dataFilepath);
        var regex = AoCRegex();

        foreach (var group in regex.Matches(corruptData).Select(match => match.Groups))
        {
            var value1 = int.Parse(group[1].Value);
            var value2 = int.Parse(group[2].Value);
            maxValue += value1 * value2;
        }

        return maxValue;
    }

    [GeneratedRegex(@"mul\((\d{1,3}),(\d{1,3})\)")]
    private static partial Regex AoCRegex();
}
