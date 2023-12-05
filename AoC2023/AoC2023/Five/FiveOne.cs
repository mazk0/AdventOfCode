namespace AoC2023.Five;

public static class FiveOne
{
    public static long Run(string dataFilepath)
    {
        var seeds = new List<long>();
        var mapNames = new List<string>();
        var currentMapName = "";
        var buildRange = false;
        var maps = new Dictionary<string, List<Map>>();
        var destinations = long.MaxValue;
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
                maps.Add(mapName, new List<Map>());
                buildRange = true;
                continue;
            }

            if (buildRange && dataRow.Length > 0 && char.IsDigit(dataRow[0]))
            {
                var parts = dataRow.Split(" ");
                maps[currentMapName].Add(new Map
                {
                    LowerLimit = long.Parse(parts[1]),
                    UpperLimit = long.Parse(parts[1]) + long.Parse(parts[2]) - 1,
                    NewValueStart = long.Parse(parts[0])
                });
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
                var hit = map.SingleOrDefault(x => x.LowerLimit <= s && s <= x.UpperLimit);

                if (hit != null)
                {
                    s -= hit.LowerLimit;
                    s += hit.NewValueStart;
                }
            }
            
            if (s < destinations)
            {
                destinations = s;
            }
        }

        return destinations;
    }
}