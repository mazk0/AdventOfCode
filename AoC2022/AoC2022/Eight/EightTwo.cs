namespace AoC2022.Eight;

public static class EightTwo
{
    public static int HowValuableMostScenicTree(string dataFilepath)
    {
        var rows = File.ReadAllLines(dataFilepath);
        var map =GenerateMap(rows);
        var yMax = map.GetLength(0);
        var xMax = map.GetLength(1);
        var blockedTrees = new List<int>();

        for (var y = 1; y < yMax - 1; y++)
        {
            for (var x = 1; x < xMax - 1; x++)
            {
                var blockedTree = new List<int>();
                var notBlocked = 0;
                for (var i = y - 1; i >= 0; i--)
                {
                    notBlocked++;
                    if (map[i, x] >= map[y, x])
                    {
                        break;
                    }
                }
                blockedTree.Add(notBlocked);
                
                notBlocked = 0;
                for (var i = y + 1; i < yMax; i++)
                {
                    notBlocked++;
                    if (map[i, x] >= map[y, x])
                    {
                        break;
                    }
                }
                blockedTree.Add(notBlocked);
                
                notBlocked = 0;
                for (var i = x - 1; i >= 0; i--)
                {
                    notBlocked++;
                    if (map[y, i] >= map[y, x])
                    {
                        break;
                    }
                }
                blockedTree.Add(notBlocked);
                
                notBlocked = 0;
                for (var i = x + 1; i < xMax; i++)
                {
                    notBlocked++;
                    if (map[y, i] >= map[y, x])
                    {
                        break;
                    }
                }
                blockedTree.Add(notBlocked);

                blockedTrees.Add(blockedTree.Aggregate((a, x) => a * x));
            }
        }

        return blockedTrees.Max();
    }

    private static int[,] GenerateMap(IReadOnlyList<string> rows)
    {
        var map = new int[rows.First().Length, rows.Count];
        
        for (var y = 0; y < rows.Count; y++)
        {
            var row = rows[y];
            for (var x = 0; x < rows.Count; x++)
            {
                map[y, x] = int.Parse(row[x].ToString());
            }
        }

        return map;
    }
}