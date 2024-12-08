namespace AoC2024.Seven;

public static class SevenTwo
{
    public static long Run(string dataFilepath)
    {
        long maxValue = 0;
        foreach (var dataRow in File.ReadLines(dataFilepath))
        {
            var split = dataRow.Split(':');
            var result = long.Parse(split[0]);
            var parts = split[1]
                .Split(' ')
                .Select(p => 
                {
                    if (long.TryParse(p, out var number))
                    {
                        return (long?)number;
                    }
                    return null;
                })
                .Where(p => p.HasValue)
                .Select(p => p.Value)
                .ToArray();

            if (CanBeSolved(0, parts[0], parts, result))
            {
                maxValue += result;
            }
        }

        return maxValue;
    }
    
    private static bool CanBeSolved(int index, long currentValue, long[] parts, long result)
    {
        if (index == parts.Length - 1)
        {
            return currentValue == result;
        }

        var nextNumber = parts[index + 1];
        return CanBeSolved(index + 1, currentValue + nextNumber, parts, result) ||
               CanBeSolved(index + 1, currentValue * nextNumber, parts, result) ||
               CanBeSolved(index + 1, currentValue * (long)Math.Pow(10, (int)Math.Log10(nextNumber) + 1) + nextNumber, parts, result);
    }
}