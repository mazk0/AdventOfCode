namespace AoC2022.Three;

public static class ThreeTwo
{
    public static int GetPrioritySum(string dataFilepath)
    {
        var prioritySum = 0;

        var rows = File.ReadAllLines(dataFilepath).ToList();
        for (var i = 0; i < rows.Count(); i += 3)
        {
            var groupRows = rows.GetRange(i, 3);
            
            var duplicateLetters = groupRows[0].Where(character => groupRows[1].Contains(character) && groupRows[2].Contains(character)).Distinct();
            prioritySum += duplicateLetters.Sum(Priority);
        }
        
        return prioritySum;
    }

    private static int Priority(char characterToPrioritize)
    {
        if (char.IsUpper(characterToPrioritize))
        {
            return characterToPrioritize - 38;
        }

        return characterToPrioritize - 96;
    }
}