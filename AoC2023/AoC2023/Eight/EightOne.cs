namespace AoC2023.Eight;

public static class EightOne
{
    public static int Run(string dataFilepath)
    {
        var stepsTeaken = 0;

        char[]? directions = null;
        var readDirections = true;
        var steps = new Dictionary<string, (string Left, string Right)>();
        foreach (var dataRow in File.ReadLines(dataFilepath))
        {
            if (readDirections)
            {
                directions = dataRow.ToCharArray();
                readDirections = false;
                continue;
            }

            if (dataRow.Length == 0)
            {
                continue;
            }

            var parts = dataRow.Split(" = ");
            var lr = parts[1].Trim('(').Trim(')').Split(", ");
            steps.Add(parts[0], (lr[0], lr[1]));
        }

        var start = "AAA";
        var end = "ZZZ";
        var current = start;
        var index = 0;
        while (current != end)
        {
            stepsTeaken++;
            
            if (index == directions.Length)
            {
                index = 0;
            }

            current = directions[index] == 'L' ? steps[current].Left : steps[current].Right;
            index++;
        }
        
        return stepsTeaken;
    }
}