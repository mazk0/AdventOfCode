namespace AoC2022.One;

public static class OneOne
{
    public static int GetMaxTotalCalories()
    {
        var maxValue = 0;
        var currentValue = 0;
        
        foreach (var dataRow in File.ReadLines("/Users/mazk0/Downloads/AoC2022/OneOneData.txt"))
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