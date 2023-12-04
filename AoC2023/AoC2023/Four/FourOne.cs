namespace AoC2023.Four;

public static class FourOne
{
    public static int Run(string dataFilepath)
    {
        var maxValue = 0;
        foreach (var dataRow in File.ReadLines(dataFilepath))
        {
            var card = dataRow.Split(": ");
            var game = card[1].Split(" | ");
            var winning = game[0].Split(" ");
            var row = game[1].Split(" ");
            
            var results = row.Where(x => winning.Contains(x) && x != "");
            maxValue += results.Count().ToBinaryNumberAt();
        }

        return maxValue;
    }
}