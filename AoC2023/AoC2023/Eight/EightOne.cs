namespace AoC2023.Eight;

public static class EightOne
{
    public static int Run(string dataFilepath)
    {
        var stepsTaken = 0;

        var directions = Array.Empty<char>();
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

        const string start = "AAA";
        const string end = "ZZZ";
        var current = start;
        var index = 0;
        while (current != end)
        {
            stepsTaken++;
            
            if (index == directions.Length)
            {
                index = 0;
            }

            current = directions[index] == 'L' ? steps[current].Left : steps[current].Right;
            index++;
        }
        
        return stepsTaken;
    }
}