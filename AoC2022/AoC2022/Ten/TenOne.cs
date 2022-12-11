namespace AoC2022.Ten;

public static class TenOne
{
    public static int GetSignalStrengthSum(string dataFilepath)
    {
        var measuredStrengths = new List<int> {0, 1};
        
        foreach (var row in File.ReadLines(dataFilepath))
        {
            if (measuredStrengths.Count > 220)
            {
                break;
            }
            
            var command = row.Split(' ');
            switch (command[0])
            {
                case "noop":
                    measuredStrengths.Add(measuredStrengths.Last());
                    break;
                case "addx":
                {
                    var latestScore = measuredStrengths.Last();
                    measuredStrengths.Add(latestScore);
                    measuredStrengths.Add(latestScore + int.Parse(command[1]));
                    break;
                }
            }
        }

        var signalStrength = 0;
        for (var i = 20; i < measuredStrengths.Count; i += 40)
        {
            signalStrength += i * measuredStrengths[i];
        }
        
        return signalStrength;
    }
}