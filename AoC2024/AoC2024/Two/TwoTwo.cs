namespace AoC2024.Two;

public static class TwoTwo
{
    public static int Run(string dataFilepath)
    {
        var maxValue = 0;

        foreach (var dataRow in File.ReadLines(dataFilepath))
        {
            var numbers = dataRow.Split(' ').Select(int.Parse).ToList();
            if (IsPassingRow(numbers))
            {
                maxValue++;
                continue;
            }

            for (var i = 0; i < numbers.Count; i++)
            {
                List<int> newNumbers = [..numbers];
                newNumbers.RemoveAt(i);
                if (IsPassingRow(newNumbers))
                {
                    maxValue++;
                    break;
                }
            }
        }

        return maxValue;
    }

    private static bool IsPassingRow(List<int> numbers)
    {
        var previous = numbers[0];
        var increasing = numbers[0] < numbers[1];

        for (var i = 1; i < numbers.Count; i++)
        {
            var current = numbers[i];
            
            if (current == previous ||
                increasing && current < previous ||
                !increasing && current > previous ||
                Math.Abs(current - previous) > 3)
            {
                return false;
            }
                
            previous = current;
        }
        
        return true;
    }
}