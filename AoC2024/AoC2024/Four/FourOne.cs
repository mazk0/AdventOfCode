namespace AoC2024.Four;

public static class FourOne
{
    private const string Word = "XMAS";
    private static readonly List<(int, int)> Directions = [(1, 0), (0, 1), (-1, 0), (0, -1), (1, 1), (1, -1), (-1, 1), (-1, -1)];
    private static readonly List<List<char>> Data = [];
    private static int _maxValue;

    public static int Run(string dataFilepath)
    {
        Data.AddRange(File.ReadLines(dataFilepath).Select(dataRow => dataRow.Select(x => x).ToList()));

        for (var y = 0; y < Data.Count; y++)
        {
            for (var x = 0; x < Data[0].Count; x++)
            {
                if (Word[0] != Data[y][x]) continue;
                
                foreach (var (dx, dy) in Directions)
                {
                    MatchNextChar(y, x, 1, dx, dy);
                }
            }

        }

        return _maxValue;
    }

    private static void MatchNextChar(int y, int x, int i, int dx, int dy)
    {
        while (true)
        {
            var nx = x + dx;
            var ny = y + dy;
            if (!IsValidPosition(nx, ny) || Word[i] != Data[ny][nx])
            {
                return;
            }

            if (i == Word.Length - 1)
            {
                _maxValue++;
                return;
            }

            y = ny;
            x = nx;
            i++;
        }
    }
    
    private static bool IsValidPosition(int x, int y)
    {
        return x >= 0 && x < Data[0].Count && y >= 0 && y < Data.Count;
    }
}