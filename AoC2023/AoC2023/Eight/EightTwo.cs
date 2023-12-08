namespace AoC2023.Eight;

public static class EightTwo
{
    public static long Run(string dataFilepath)
    {
        var directions = Array.Empty<char>();
        var readDirections = true;
        var steps = new Dictionary<string, (string Left, string Right)>();
        var starts = new List<string>();
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

            if (parts[0].Last() == 'A')
            {
                starts.Add(parts[0]);
            }
        }
        
        const char end = 'Z';
        var stepsPerIteration = new List<long>();
        foreach (var start in starts)
        {
            var stepsTaken = 0;
            var current = start;
            var index = 0;
            while (current.Last() != end)
            {
                stepsTaken++;

                if (index == directions.Length)
                {
                    index = 0;
                }

                current = directions[index] == 'L' ? steps[current].Left : steps[current].Right;
                index++;
            }

            stepsPerIteration.Add(stepsTaken);
        }

        return stepsPerIteration.Aggregate(Lcm);
    }
    
    private static long Lcm(long a, long b)
    {
        return a * b / Gcd(a, b);
    }
    
    private static long Gcd(long a, long b)
    {
        while (b != 0)
        {
            var temp = b;
            b = a % b;
            a = temp;
        }
        
        return a;
    }
}