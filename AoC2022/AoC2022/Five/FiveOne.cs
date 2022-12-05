namespace AoC2022.Five;

public static class FiveOne
{
    public static string GetSupplyStacks(string dataFilepath)
    {
        var hasLoadedStacks = false;
        var stacks = CreateStacks(10);

        foreach (var row in File.ReadLines(dataFilepath))
        {
            if (row.StartsWith(" 1"))
            {
                hasLoadedStacks = true;
                continue;
            }

            LoadDataToStacks(hasLoadedStacks, row, stacks);
            ReverseStacks(hasLoadedStacks, row, stacks);
            RearrangeCrates(hasLoadedStacks, row, stacks);
        }

        return GenerateResults(stacks);
    }
    
    private static List<Stack<string>> CreateStacks(int numberOfStacks)
    {
        var stacks = new List<Stack<string>>(new Stack<string>[numberOfStacks]);
        for (var i = 0; i < stacks.Capacity; i++)
        {
            stacks[i] = new Stack<string>();
        }

        return stacks;
    }
    
    private static void LoadDataToStacks(bool hasLoadedStacks, string row, List<Stack<string>> stacks)
    {
        if (hasLoadedStacks)
        {
            return;
        }
        
        var rowIndex = 1;
        for (var i = 1; i < stacks.Capacity; i++)
        {
            var crateLabel = row[rowIndex].ToString();
            CreateLabel(stacks, crateLabel, i);
            
            rowIndex += 4;
        }
    }

    private static void CreateLabel(IReadOnlyList<Stack<string>> stacks, string crateLabel, int i)
    {
        if (!string.IsNullOrWhiteSpace(crateLabel))
        {
            stacks[i].Push(crateLabel);
        }
    }
    
    private static void ReverseStacks(bool hasLoadedStacks, string row, List<Stack<string>> stacks)
    {
        if (!hasLoadedStacks || !string.IsNullOrWhiteSpace(row))
        {
            return;
        }
        
        for (var i = 0; i < stacks.Capacity; i++)
        {
            var reversedStack = new Stack<string>(stacks[i].Reverse());
            stacks[i].Clear();
            while (reversedStack.TryPop(out var value))
            {
                stacks[i].Push(value);
            }
        }
    }

    private static void RearrangeCrates(bool hasLoadedStacks, string row, List<Stack<string>> stacks)
    {
        if (!hasLoadedStacks || !row.StartsWith("move "))
        {
            return;
        }
        
        var command = row.Split(' ');
        for (var i = 0; i < Convert.ToInt32(command[1]); i++)
        {
            stacks[Convert.ToInt32(command[5])].Push(stacks[Convert.ToInt32(command[3])].Pop());
        }
    }

    private static string GenerateResults(List<Stack<string>> stacks)
    {
        var result = string.Empty;
        for (var i = 0; i < stacks.Capacity; i++)
        {
            if (stacks[i].TryPeek(out var value))
            {
                result += value;
            }
        }

        return result;
    }
}