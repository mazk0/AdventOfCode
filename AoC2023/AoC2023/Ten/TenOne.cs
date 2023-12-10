namespace AoC2023.Ten;

public static class TenOne
{
    public static int Run(string dataFilepath)
    {
        var map = File.ReadLines(dataFilepath).Select(dataRow => dataRow.ToCharArray().ToList()).ToList();
        var start = FindStart(map);

        var seen = new List<(int, int)> {start};
        var toVisit = new Queue<(int, int)>();
        toVisit.Enqueue(start);

        while (toVisit.Count != 0)
        {
            var (row, column) = toVisit.Dequeue();
            var current = map[row][column];

            if (row > 0 && "S|JL".Contains(current) && "|F7".Contains(map[row - 1][column]) && !seen.Contains((row - 1, column)))
            {
                seen.Add((row - 1, column));
                toVisit.Enqueue((row - 1, column));
            }

            if (row < map.Count - 1 && "S|F7".Contains(current) && "|JL".Contains(map[row + 1][column]) && !seen.Contains((row + 1, column)))
            {
                seen.Add((row + 1, column));
                toVisit.Enqueue((row + 1, column));
            }

            if (column > 0 && "S-J7".Contains(current) && "-LF".Contains(map[row][column - 1]) && !seen.Contains((row, column - 1)))
            {
                seen.Add((row, column - 1));
                toVisit.Enqueue((row, column - 1));
            }

            if (column < map[row].Count - 1 && "S-LF".Contains(current) && "-J7".Contains(map[row][column + 1]) && !seen.Contains((row, column + 1)))
            {
                seen.Add((row, column + 1));
                toVisit.Enqueue((row, column + 1));
            }
        }

        return seen.Count / 2;
    }

    private static (int row, int column) FindStart(List<List<char>> map)
    {
        (int r, int c) start = (0, 0);
        for (var r = 0; r < map.Count; r++)
        {
            for (var c = 0; c < map[r].Count; c++)
            {
                if (map[r][c] == 'S')
                {
                    return (r, c);
                }
            }
        }

        return start;
    }
}