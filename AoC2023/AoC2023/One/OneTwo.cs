namespace AoC2023.One;

public static class OneTwo
{
    public static int Run(string dataFilepath)
    {
        var numbers = new[] {"1", "2", "3", "4", "5", "6", "7", "8", "9", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
        
        var maxValue = 0;
        foreach (var dataRow in File.ReadLines(dataFilepath))
        {
            var firstLowestIndex = dataRow.Length;
            var fistNumber = 0;
            var lastHighestIndex = -1;
            var lastNumber = 0;
            
            for(var i = 1; i < numbers.Length + 1; i++)
            {
                var number = numbers[i - 1];
                var firstIndex = dataRow.IndexOf(number, StringComparison.OrdinalIgnoreCase);
                var lastIndex = dataRow.LastIndexOf(number, StringComparison.OrdinalIgnoreCase);

                if (firstIndex == -1 || lastIndex == -1)
                    continue;
                
                if (firstIndex < firstLowestIndex)
                {
                    firstLowestIndex = firstIndex;
                    if (i > 9)
                        i -= 9;
                    fistNumber = i;
                }

                if (lastIndex > lastHighestIndex)
                {
                    lastHighestIndex = lastIndex;
                    if (i > 9)
                        i -= 9;
                    lastNumber = i;
                }
            }
            
            maxValue += fistNumber * 10 + lastNumber;
        }

        return maxValue;
    }
}