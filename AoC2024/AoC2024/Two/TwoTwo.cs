namespace AoC2024.Two;

public class TwoTwo
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
            for (var i = 0; i < rightList.Count; i++)
            {
                if (rightList[i] == number)
                {
                    count++;
                }
                if(rightList[i] > number)
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