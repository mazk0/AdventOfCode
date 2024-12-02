namespace AoC2024.Two;

public static class TwoOne
{
    public static int Run(string dataFilepath)
    {
        var maxValue = 0;

        foreach (var dataRow in File.ReadLines(dataFilepath))
        {
            var previous = 0;
            var numbers = dataRow.Split(' ').Select(int.Parse).ToArray();
            var increasing = numbers[0] < numbers[1];
            var dampened = false;
            
            for (var i = 0; i < numbers.Length; i++)
            {
                var current = numbers[i];
                
                if (current == previous)
                {
                    // Console.WriteLine($"{dataRow}: same");
                    if (!dampened)
                    {
                        dampened = true;
                    }
                    else
                    {
                        break;
                    }
                }
                
                if (i > 0 && (increasing && current < previous || !increasing && current > previous))
                {
                    // Console.WriteLine($"{dataRow}: changed direction");
                    if (!dampened)
                    {
                        dampened = true;
                    }
                    else
                    {
                        break;
                    }
                }

                if (i > 0 && Math.Abs(current - previous) > 3)
                {
                    // Console.WriteLine($"{dataRow}: changed more than 3");
                    if (!dampened)
                    {
                        dampened = true;
                    }
                    else
                    {
                        break;
                    }
                }
                
                previous = current;
                if (i == numbers.Length - 1)
                {
                    maxValue++;
                }
            }
        }

        return maxValue;
    }
}