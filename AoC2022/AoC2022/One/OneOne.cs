namespace AoC2022.One;

public static class OneOne
{
    public static int GetMaxTotalCalories(string dataFilepath)
    {
        var maxValue = 0;
        var currentValue = 0;
        
        foreach (var dataRow in File.ReadLines(dataFilepath))
        {
            if (string.IsNullOrEmpty(dataRow))
            {
                if (currentValue > maxValue)
                {
                    maxValue = currentValue;
                }
                
                currentValue = 0;
                
                continue;
            }

            currentValue += int.Parse(dataRow);
        }

        return maxValue;
    }
}