namespace AoC2023.Nine;

public static class NineOne
{
    public static int Run(string dataFilepath)
    {
        var maxValue = 0;
        foreach (var dataRow in File.ReadLines(dataFilepath))
        {
            var history = dataRow.Split(' ').Select(int.Parse).ToList();
            var lastNumbers = new List<int> {history.Last()};
            while (history.Any(x => x != 0))
            {
                history = history.Zip(history.Skip(1), (a, b) => b - a).ToList();
                lastNumbers.Add(history.Last());
            }

            maxValue += lastNumbers.Sum();
        }

        return maxValue;
    }
}