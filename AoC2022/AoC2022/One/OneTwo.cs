namespace AoC2022.One;

public static class OneTwo
{
    public static int GetMaxTotalCaloriesForTopThree()
    {
        var calories = new List<int>();
        var currentValue = 0;
        
        foreach (var dataRow in File.ReadLines("/Users/mazk0/Downloads/AoC2022/OneOneData.txt"))
        {
            if (string.IsNullOrEmpty(dataRow))
            {
                calories.Add(currentValue);

                currentValue = 0;

                continue;
            }

            currentValue += int.Parse(dataRow);
        }

        return calories.OrderByDescending(calorie => calorie).Take(3).Sum();
    }
}