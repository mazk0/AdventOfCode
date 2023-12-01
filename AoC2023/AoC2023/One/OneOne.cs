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
                
                if (char.IsDigit(currentFirst) && firstDigit == 0)
                {
                    firstDigit = Convert.ToInt32(char.GetNumericValue(currentFirst));
                }
                   
                if (char.IsDigit(currentLast) && lastDigit == 0)
                {
                    lastDigit = Convert.ToInt32(char.GetNumericValue(currentLast));
                }
                
                if (firstDigit != 0 && lastDigit != 0)
                {
                    maxValue = maxValue + firstDigit * 10 + lastDigit;
                    break;
                }
            }
        }

        return maxValue;
    }
}