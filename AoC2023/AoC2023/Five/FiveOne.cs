namespace AoC2023.Five;

public static class FiveOne
{
    public static long Run(string dataFilepath)
    {
        var seeds = new List<long>();
        var mapNames = new List<string>();
        var currentMapName = "";
        var buildRange = false;
        var maps = new Dictionary<string, Dictionary<long, long>>();
        var destinations = new List<long>();
        foreach (var dataRow in File.ReadLines(dataFilepath))
        {
            if (dataRow.StartsWith("seeds"))
            {
                dataRow.Split(": ")[1].Split(" ").ToList().ForEach(x => seeds.Add(long.Parse(x)));
                continue;
            }

            if (dataRow.Contains("map"))
            {
                var mapName = dataRow.Split(" ")[0];
                mapNames.Add(mapName);
                currentMapName = mapName;
                maps.Add(mapName, new Dictionary<long, long>());
                buildRange = true;
                continue;
            }

            if (buildRange && dataRow.Length > 0 && char.IsDigit(dataRow[0]))
            {
                var parts = dataRow.Split(" ");
                for (var i = 0; i < long.Parse(parts[2]); i++)
                {
                    maps[currentMapName].Add(long.Parse(parts[1]) + i, long.Parse(parts[0]) + i);
                }
            }

            if (dataFilepath.Length == 0 && buildRange)
                buildRange = false;
            
        }

        foreach (var seed in seeds)
        {
            var s = seed;
            foreach (var mapName in mapNames)
            {
                var map = maps[mapName];
                if (map.TryGetValue(s, out var value))
                {
                    s = value;
                }
            }
            
            destinations.Add(s);
        }

        return destinations.Min();
    }
}