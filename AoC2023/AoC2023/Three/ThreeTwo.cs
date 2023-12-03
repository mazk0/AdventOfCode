namespace AoC2023.Three;

public static class ThreeTwo
{
    public static int Run(string dataFilepath)
    {
        var maxValue = 0;
        var data = File.ReadAllLines(dataFilepath);
        var paddedData = data.ToPaddedData('.');

        for (var i = 0; i < paddedData.Length; i++)
        {
            var row = paddedData[i];
            for (var j = 0; j < row.Length; j++)
            {
                if (paddedData[i][j] == '*')
                {
                    maxValue += GetGearing(paddedData, i, j);
                }
            }
        }

        return maxValue;
    }

    private static int GetGearing(string[] data, int i, int j)
    {
        var numbers = new List<string>();
        if (char.IsDigit(data[i - 1][j - 1]))
        {
            numbers.Add(GetDigit(data, i - 1, j - 1));
        }

        if (char.IsDigit(data[i - 1][j]))
        {
            numbers.Add(GetDigit(data, i - 1, j));
        }

        if (char.IsDigit(data[i - 1][j + 1]))
        {
            numbers.Add(GetDigit(data, i - 1, j + 1));
        }

        if (char.IsDigit(data[i][j - 1]))
        {
            numbers.Add(GetDigit(data, i, j - 1));
        }

        if (char.IsDigit(data[i][j + 1]))
        {
            numbers.Add(GetDigit(data, i, j + 1));
        }

        if (char.IsDigit(data[i + 1][j - 1]))
        {
            numbers.Add(GetDigit(data, i + 1, j - 1));
        }

        if (char.IsDigit(data[i + 1][j]))
        {
            numbers.Add(GetDigit(data, i + 1, j));
        }

        if (char.IsDigit(data[i + 1][j + 1]))
        {
            numbers.Add(GetDigit(data, i + 1, j + 1));
        }

        var distinctNumbers = numbers.Distinct().ToArray();
        
        if (distinctNumbers.Length != 2)
        {
            return 0;
        }
        
        return int.Parse(distinctNumbers[0]) * int.Parse(distinctNumbers[1]);
    }

    private static string GetDigit(IReadOnlyList<string> data, int i, int j)
    {
        var x = 0;
        while (char.IsDigit(data[i][j - x]))
        {
            x++;
        }

        x--;

        var number = "";
        while (char.IsDigit(data[i][j - x]))
        {
            number += data[i][j - x];
            x--;
        }

        return number;
    }
}