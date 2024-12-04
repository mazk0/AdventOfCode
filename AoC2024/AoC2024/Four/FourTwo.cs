namespace AoC2024.Four;

public static class FourTwo
{
    public static int Run(string dataFilepath)
    {
        var maxValue = 0;
        List<List<char>> data = [];
        data.AddRange(File.ReadLines(dataFilepath).Select(dataRow => dataRow.Select(x => x).ToList()));
        List<((int, int), (int, int))> directions = [((1, 1), (-1, -1)), ((1, -1), (-1, 1))];

        for (var y = 0; y < data.Count; y++)
        {
            for (var x = 0; x < data[0].Count; x++)
            {
                if ('A' != data[y][x]) continue;

                var matches = 0;
                foreach (var ((dx1, dy1), (dx2, dy2)) in directions)
                {
                    var nx1 = x + dx1;
                    var ny1 = y + dy1;
                    var nx2 = x + dx2;
                    var ny2 = y + dy2;

                    if (!IsValidPosition(nx1, ny1, data) || !IsValidPosition(nx2, ny2, data)) continue;
                    
                    if (('M' == data[ny1][nx1] && 'S' == data[ny2][nx2]) || ('S' == data[ny1][nx1] && 'M' == data[ny2][nx2]))
                    {
                        matches++;
                    }
                }

                if (matches == 2)
                {
                    maxValue++;
                }
            }
        }

        return maxValue;
    }
    
    private static bool IsValidPosition(int x, int y, List<List<char>> data)
    {
        return x >= 0 && x < data[0].Count && y >= 0 && y < data.Count;
    }
}