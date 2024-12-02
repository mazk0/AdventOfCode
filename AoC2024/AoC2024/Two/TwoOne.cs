namespace AoC2024.Two;

public static class TwoOne
{
    public static int Run(string dataFilepath)
    {
        var maxValue = 0;

        foreach (var dataRow in File.ReadLines(dataFilepath))
        {
            var numbers = dataRow.Split(' ').Select(int.Parse).ToArray();
            var previous = numbers[0];
            var increasing = numbers[0] < numbers[1];
            
            for (var i = 1; i < numbers.Length; i++)
            {
                var current = numbers[i];
                
                if (current == previous ||
                    increasing && current < previous ||
                    !increasing && current > previous ||
                    Math.Abs(current - previous) > 3)
                {
                    break;
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
