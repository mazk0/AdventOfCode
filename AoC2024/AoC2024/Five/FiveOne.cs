namespace AoC2024.Five;

public static class FiveOne
{
    private static readonly Dictionary<int, List<int>> Rules = new();
    public static int Run(string dataFilepath)
    {
        var maxValue = 0;
        var pageLists = LoadListsAndRules(dataFilepath);

        foreach (var pageList in pageLists)
        {
            var count = 0;
            for (var i = 1; i < pageList.Count; i++)
            {
                if (ContainsFromIndexToStart(pageList, pageList[i], i))
                {
                    count++;
                }
            }

            if (count == pageList.Count - 1)
            {
                maxValue += pageList[count / 2];
            }
        }

        return maxValue;
    }

    private static bool ContainsFromIndexToStart(List<int> list, int number, int startIndex)
    {
        if (!Rules.TryGetValue(number, out var rules))
        {
            return true;
        }

        for (var i = startIndex - 1; i >= 0; i--)
        {
            if (rules.Contains(list[i]))
            {
                return false;
            }
        }
        
        return true;
    }
    
    private static List<List<int>> LoadListsAndRules(string dataFilepath)
    {
        var pageLists = new List<List<int>>();
        var readRules = true;
        foreach (var dataRow in File.ReadLines(dataFilepath))
        {
            if (string.IsNullOrWhiteSpace(dataRow))
            {
                readRules = false;
                continue;
            }

            if (readRules)
            {
                var ruleParts = dataRow.Split("|");
                var key = int.Parse(ruleParts[0]);
                var value = int.Parse(ruleParts[1]);
                if (!Rules.TryGetValue(key, out var values))
                {
                    Rules[key] = [value];
                }
                else
                {
                    values.Add(value);
                }
            }
            else
            {
                var pageList = dataRow.Split(",").Select(int.Parse).ToList();
                pageLists.Add(pageList);
            }
        }

        return pageLists;
    }
}