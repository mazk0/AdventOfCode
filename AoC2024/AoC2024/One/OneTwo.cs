namespace AoC2024.One;

public static class OneTwo
{
    public static int Run(string dataFilepath)
    {
        var maxValue = 0;
        var leftList = new List<int>();
        var rightList = new List<int>();
        var dict = new Dictionary<int, int>();

        foreach (var dataRow in File.ReadLines(dataFilepath))
        {
            var parts = dataRow.Split("   ");
            leftList.Add(int.Parse(parts[0]));
            rightList.Add(int.Parse(parts[1]));
        }
        
        rightList.Sort();

        foreach (var number in leftList)
        {
            if (dict.TryGetValue(number, out var value))
            {
                maxValue += value;
                continue;
            }

            var count = 0;
            foreach (var rightNumber in rightList)
            {
                if (rightNumber == number)
                {
                    count++;
                }
                if(rightNumber > number)
                {
                    break;
                }
            }

            var sum = number * count;
            dict.Add(number, sum);
            maxValue += sum;
        }


        return maxValue;
    }
}