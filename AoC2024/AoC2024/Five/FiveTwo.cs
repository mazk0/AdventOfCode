namespace AoC2024.Five;

public static class FiveTwo
{
    private static readonly Dictionary<int, List<int>> Rules = new();
    public static int Run(string dataFilepath)
    {
        var maxValue = 0;
        var pageLists = LoadListsAndRules(dataFilepath);
        var brokenLines = new List<List<int>>();
        
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

            if (count != pageList.Count - 1)
            {
                brokenLines.Add(pageList);
            }
        }

        foreach (var brokenLine in brokenLines)
        {
            var sortedList = SortList(brokenLine);
            maxValue += sortedList[sortedList.Count / 2];
        }

        return maxValue;
    }
    
    private static List<int> SortList(List<int> list)
    {
        var sortedList = new List<int>();
        
        for (var index = list.Count - 1; index >= 0; index--)
        {
            var number = list[index];
            InsertNumberIntoSortedList(sortedList, number);
        }
        
        return sortedList;
    }

    private static void InsertNumberIntoSortedList(List<int> sortedList, int number)
    {
        if (Rules.TryGetValue(number, out var rules))
        {
            var lowestIndex = FindLowestIndex(sortedList, rules);
            
            if (lowestIndex == int.MaxValue)
            {
                sortedList.Add(number);
            }
            else
            {
                sortedList.Insert(lowestIndex, number);
            }
        }
        else
        {
            sortedList.Add(number);
        }
    }

    private static int FindLowestIndex(List<int> sortedList, List<int> rules)
    {
        var lowestIndex = int.MaxValue;
        
        foreach (var rule in rules)
        {
            var ruleIndex = sortedList.IndexOf(rule);
            
            if (ruleIndex != -1 && ruleIndex < lowestIndex)
            {
                lowestIndex = ruleIndex;
            }
        }
        
        return lowestIndex;
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