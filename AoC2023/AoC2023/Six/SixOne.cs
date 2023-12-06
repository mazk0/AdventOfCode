namespace AoC2023.Six;

public static class SixOne
{
    public static int Run(string dataFilepath)
    {
        var maxValue = 1;
        var races = new List<Race>();
        var data = File.ReadLines(dataFilepath);
        var numberLine = data.Select(line => line.Split(":")).Select(parts => parts[1].Trim().Split("  ").Where(x => x != "").ToList()).ToList();
        for (var i = 0; i < numberLine[0].Count; i++)
        {
            races.Add(new Race(int.Parse(numberLine[0][i].Trim()), int.Parse(numberLine[1][i].Trim())));
        }
        
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

public record Race(int Time, int Distance);