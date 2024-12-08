namespace AoC2024.Six;

public static class SixTwo
{
    private const char Visited = 'X';
    private const char Obstacle = '#';
    private const char TestObstacle = 'T';
    private const char Empty = '.';
    private const char Start = '^';

    public static int Run(string dataFilepath)
    {
        var (layout, start) = LoadLayout(dataFilepath);
        var traversedLayout = TraverseLayout(layout, start.y, start.x, 'U');
        
        var visitedCoordinated = GetVisitedCoordinates(traversedLayout);

        return visitedCoordinated
            .Except([(start.y, start.x)])
            .Count(coordinate => TraverseLoop(layout, start.y, start.x, 'U', coordinate.y, coordinate.x));
    }
    
    private static bool TraverseLoop(char[][] layout, int y, int x, char direction, int obstacleY, int obstacleX)
    {
        var visited = new HashSet<(int y, int x, char direction)>();
        layout[obstacleY][obstacleX] = TestObstacle;
        
        while (true)
        {
            if (!visited.Add((y, x, direction)))
            {
                layout[obstacleY][obstacleX] = Empty;
                return true;
            }

            if (IsOutOfBound(layout, y, x))
            {
                break;
            }
            
            switch (direction)
            {
                case 'U':
                    var uPoint = layout[y - 1][x];
                    if (uPoint != Obstacle && uPoint != TestObstacle) y--;
                    else direction = 'R';
                    break;
                case 'R':
                    var rPoint = layout[y][x + 1];
                    if (rPoint != Obstacle && rPoint != TestObstacle) x++;
                    else direction = 'D';
                    break;
                case 'D':
                    var dPoint = layout[y + 1][x];
                    if (dPoint != Obstacle && dPoint != TestObstacle) y++;
                    else direction = 'L';
                    break;
                case 'L':
                    var lPoint = layout[y][x - 1];
                    if (lPoint != Obstacle && lPoint != TestObstacle) x--;
                    else direction = 'U';
                    break;
            }
        }

        layout[obstacleY][obstacleX] = Empty;
        return false;
    }

    private static (int y, int x)[] GetVisitedCoordinates(char[][] layout)
    {
        var visitedCoordinates = new List<(int y, int x)>();
        for (var y = 0; y < layout.Length; y++)
        {
            for (var x = 0; x < layout[y].Length; x++)
            {
                if (layout[y][x] == Visited)
                {
                    visitedCoordinates.Add((y, x));
                }
            }
        }

        return visitedCoordinates.ToArray();
    }

    private static char[][] TraverseLayout(char[][] layout, int y, int x, char direction)
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

        return layout;
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