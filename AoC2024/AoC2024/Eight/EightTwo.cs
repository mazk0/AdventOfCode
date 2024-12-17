namespace AoC2024.Eight;

public static class EightTwo
{
    private static int _width;
    private static int _height;
    
    public static int Run(string dataFilepath)
    {
        var antennas = LoadAntennas(dataFilepath);
        HashSet<(int y, int x)> antinodes = [];

        foreach (var antennasOfType in antennas.Values)
        {
            for (var antennaOne = 0; antennaOne < antennasOfType.Count; antennaOne++)
            {
                for (var antennaTwo = antennaOne + 1; antennaTwo < antennasOfType.Count; antennaTwo++)
                {
                    var diff = (antennasOfType[antennaTwo].y - antennasOfType[antennaOne].y, antennasOfType[antennaTwo].x - antennasOfType[antennaOne].x);
                    AddAntinodes(antinodes, antennasOfType[antennaOne], diff, -1);
                    AddAntinodes(antinodes, antennasOfType[antennaTwo], diff, 1);
                }
            }
        }

        return antinodes.Count;
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
                
                if (!antennas.TryGetValue(character, out var value))
                {
                    value = [];
                    antennas[character] = value;
                }

                value.Add((y, x));
            }
        }

        return antennas;
    }
    
    private static bool IsInBound(int y, int x)
    {
        return x >= 0 && x < _width && y >= 0 && y < _height;
    }
    
    private static void AddAntinodes(HashSet<(int y, int x)> antinodes, (int y, int x) start, (int y, int x) diff, int direction)
    {
        var currentLocation = start;
        while (IsInBound(currentLocation.y, currentLocation.x))
        {
            antinodes.Add(currentLocation);
            currentLocation = (currentLocation.y + direction * diff.y, currentLocation.x + direction * diff.x);
        }
    }
}