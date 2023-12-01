namespace AoC2023.One;

public static class OneOne
{
    public static int Run(string dataFilepath)
    {
        var maxValue = 0;
        foreach (var dataRow in File.ReadLines(dataFilepath))
        {
            var firstDigit = 0;
            var lastDigit = 0;
            for (var i = 0; i < dataRow.Length; i++)
            {
                var currentFirst = dataRow[i];
                var currentLast = dataRow[dataRow.Length - 1 - i];
                
                if (48 < currentFirst && currentFirst < 58 && firstDigit == 0)
                {
                    firstDigit = currentFirst - 48;
                }
                   
                if (48 < currentLast && currentLast < 58 && lastDigit == 0)
                {
                    lastDigit = currentLast - 48;
                }
                
                if (firstDigit != 0 && lastDigit != 0)
                {
                    maxValue += firstDigit * 10 + lastDigit;
                    break;
                }
            }
        }

        return maxValue;
    }
}