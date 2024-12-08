namespace AoC2024.Six;

public static class SixOne
{
    private const char Visited = 'X';
    private const char Obstacle = '#';
    private const char Start = '^';

    public static int Run(string dataFilepath)
    {
        var (layout, start) = LoadLayout(dataFilepath);
        TraverseLayout(layout, start.y, start.x, 'U');
        return CountVisited(layout);
    }

    private static int CountVisited(char[][] layout)
    {
        return layout.Sum(row => row.Count(cell => cell == Visited));
    }

    private static void TraverseLayout(char[][] layout, int y, int x, char direction)
    {
        while (true)
        {
            layout[y][x] = Visited;

            if (IsOutOfBound(layout, y, x))
            {
                break;
            }

            switch (direction)
            {
                case 'U':
                    if (layout[y - 1][x] != Obstacle) y--;
                    else direction = 'R';
                    break;
                case 'R':
                    if (layout[y][x + 1] != Obstacle) x++;
                    else direction = 'D';
                    break;
                case 'D':
                    if (layout[y + 1][x] != Obstacle) y++;
                    else direction = 'L';
                    break;
                case 'L':
                    if (layout[y][x - 1] != Obstacle) x--;
                    else direction = 'U';
                    break;
            }
        }
    }

    private static bool IsOutOfBound(char[][] layout, int y, int x)
    {
        return x <= 0 || x >= layout[0].Length - 1 || y <= 0 || y >= layout.Length - 1;
    }

    private static (char[][] layout, (int x, int y) start) LoadLayout(string dataFilepath)
    {
        var lines = File.ReadAllLines(dataFilepath);
        var layout = lines.Select(line => line.ToCharArray()).ToArray();
        var start = lines
            .Select((line, i) => (line.IndexOf(Start), i))
            .FirstOrDefault(pos => pos.Item1 != -1);

        return (layout, start);
    }
}
