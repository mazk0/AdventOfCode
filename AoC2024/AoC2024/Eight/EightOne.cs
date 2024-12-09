namespace AoC2024.Eight;

public static class EightOne
{
    private static int _width;
    private static int _height;
    
    public static int Run(string dataFilepath)
    {
        var antennas = LoadAntennas(dataFilepath);
        HashSet<(int y, int x)> antinodes = [];

        foreach (var antennasOfType in antennas.Select(antenna => antenna.Value))
        {
            for (var antenna1 = 0; antenna1 < antennasOfType.Count; antenna1++)
            {
                for (var antenna2 = antenna1 + 1; antenna2 < antennasOfType.Count; antenna2++)
                {
                    var diff = (antennasOfType[antenna2].y - antennasOfType[antenna1].y, antennasOfType[antenna2].x - antennasOfType[antenna1].x);
                    antinodes.Add((antennasOfType[antenna1].y - diff.Item1, antennasOfType[antenna1].x - diff.Item2));
                    antinodes.Add((antennasOfType[antenna2].y + diff.Item1, antennasOfType[antenna2].x + diff.Item2));
                }
            }
        }

        return antinodes.Count(a => !IsOutOfBound(a.y, a.x));
    }

    private static Dictionary<char, List<(int y, int x)>> LoadAntennas(string dataFilepath)
    {
        var lines = File.ReadAllLines(dataFilepath);
        _width = lines[0].Length;
        _height = lines.Length;
        Dictionary<char, List<(int y, int x)>> antennas = new();

        for (var y = 0; y < _height; y++)
        {
            for (var x = 0; x < _width; x++)
            {
                var character = lines[y][x];

                if (character == '.') continue;
                
                if (!antennas.ContainsKey(character))
                {
                    antennas[character] = new List<(int y, int x)>();
                }

                antennas[character].Add((y, x));
            }
        }

        return antennas;
    }
    
    private static bool IsOutOfBound(int y, int x)
    {
        return x < 0 || x > _width - 1 || y < 0 || y > _height - 1;
    }
}
