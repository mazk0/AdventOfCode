namespace AoC2022.Three;

public static class ThreeOne
{
    public static int GetPrioritySum(string dataFilepath)
    {
        var prioritySum = 0;

        foreach (var row in File.ReadLines(dataFilepath))
        {
            var middleIndex = row.Length / 2;
            var firstCompartment = row[..middleIndex];
            var secondCompartment = row[middleIndex..];

            var duplicateLetters = firstCompartment.Where(letter => secondCompartment.Contains(letter)).Distinct();
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