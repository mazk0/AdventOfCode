namespace AoC2024.One;

public static class OneOne
{
    public static int Run(string dataFilepath)
    {
        var leftList = new List<int>();
        var rightList = new List<int>();

        foreach (var dataRow in File.ReadLines(dataFilepath))
        {
            var parts = dataRow.Split("   ");
            leftList.Add(int.Parse(parts[0]));
            rightList.Add(int.Parse(parts[1]));
        }
        
        leftList.Sort();
        rightList.Sort();

        return leftList.Select((t, i) => Math.Abs(t - rightList[i])).Sum();
    }
}