namespace AoC2023.Three;

public static class ThreeOne
{
    public static int Run(string dataFilepath)
    {
        var maxValue = 0;
        var data = File.ReadAllLines(dataFilepath);
        var paddedData = data.ToPaddedData('.');

        for (var i = 0; i < paddedData.Length; i++)
        {
            var number = "";
            var row = paddedData[i];
            var nextToChar = false;
            
            for (var j = 0; j < row.Length; j++)
            {
                if (char.IsDigit(paddedData[i][j]))
                {
                    number += paddedData[i][j];

                    if (!nextToChar)
                    {
                        nextToChar = IsNextToChar(paddedData, i, j);
                    }
                }
                else
                {
                    if (number.Length > 0)
                    {
                        if (nextToChar)
                        {
                            maxValue += int.Parse(number);
                        }
                    }

                    nextToChar = false;
                    number = "";
                }
            }
        }

        return maxValue;
    }

    private static bool IsNextToChar(string[] data, int i, int j)
    {
        return
            !char.IsDigit(data[i - 1][j - 1]) && data[i - 1][j - 1] != '.'
            || !char.IsDigit(data[i - 1][j]) && data[i - 1][j] != '.'
            || !char.IsDigit(data[i - 1][j + 1]) && data[i - 1][j + 1] != '.'
            
            || !char.IsDigit(data[i][j - 1]) && data[i][j - 1] != '.'
            || !char.IsDigit(data[i][j + 1]) && data[i][j + 1] != '.'
            
            || !char.IsDigit(data[i + 1][j - 1]) && data[i + 1][j - 1] != '.'
            || !char.IsDigit(data[i + 1][j]) && data[i + 1][j] != '.'
            || !char.IsDigit(data[i + 1][j + 1]) && data[i + 1][j + 1] != '.';
    }
}