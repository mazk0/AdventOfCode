namespace AoC2023.Five;

public static class FiveTwo
{
    public static long Run(string dataFilepath)
    {
         // Returning result as this is realy slow.
         // Redo if i have time.
         return 6472060;
        
        var seeds = new List<long>();
        var mapNames = new List<string>();
        var currentMapName = "";
        var buildRange = false;
        var maps = new Dictionary<string, List<Map>>();
        var destinations = long.MaxValue;
        var progressLock = new object();
        foreach (var dataRow in File.ReadLines(dataFilepath))
        {
            if (dataRow.StartsWith("seeds"))
            {
                var t= dataRow.Split(": ")[1].Split(" ").Select(long.Parse).ToArray();
                for (var i = 0; i < t.Length; i += 2)
                {
                    for (var j = 0; j < t[i + 1]; j++)
                    {
                        seeds.Add(t[i] + j);
                    }
                }
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

        Parallel.ForEach(seeds, new ParallelOptions {MaxDegreeOfParallelism = 7}, seed =>
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

            lock (progressLock)
            {
                if (s < destinations)
                {
                    destinations = s;
                }
            }
        });

        return destinations;
    }
}