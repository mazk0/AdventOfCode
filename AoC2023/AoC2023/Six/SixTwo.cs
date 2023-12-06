namespace AoC2023.Six;

public static class SixTwo
{
    public static int Run(string dataFilepath)
    {
        var maxValue = 1;
        var races = new List<Race2>();
        var data = File.ReadLines(dataFilepath);
        var numberLine = data.Select(line => line.Split(":")).Select(parts => parts[1]).ToList();
        races.Add(new Race2(long.Parse(numberLine[0].Replace(" ", "")), long.Parse(numberLine[1].Replace(" ", ""))));
        
        foreach (var race in races)
        {
            var wins = 0;
            for (var i = 0; i < race.Time; i++)
            {
                var raceTime = race.Time - i;
                var distance = i * raceTime;
        
                if (distance > race.Distance)
                {
                    wins++;
                }
            }
            
            maxValue *= wins;
        }

        return maxValue;
    }
}

public record Race2(long Time, long Distance);