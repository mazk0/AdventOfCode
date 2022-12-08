namespace AoC2022.Eight;

public static class EightOne
{
    public static int HowMayTreesVisible(string dataFilepath)
    {
        var rows = File.ReadAllLines(dataFilepath);
        var map =GenerateMap(rows);
        var yMax = map.GetLength(0);
        var xMax = map.GetLength(1);
        var blockedTrees = new List<string>();

        for (var y = 1; y < yMax - 1; y++)
        {
            for (var x = 1; x < xMax - 1; x++)
            {
                var blockedTree = new List<string>();
                for (var i = y - 1; i >= 0; i--)
                {
                    if (map[i, x] >= map[y, x])
                    {
                        blockedTree.Add($"{y}-{x}");
                        
                        break;
                    }
                }
                
                for (var i = y + 1; i < yMax; i++)
                {
                    if (map[i, x] >= map[y, x])
                    {
                        blockedTree.Add($"{y}-{x}");
                        
                        break;
                    }
                }
                
                for (var i = x - 1; i >= 0; i--)
                {
                    if (map[y, i] >= map[y, x])
                    {
                        blockedTree.Add($"{y}-{x}");
                        
                        break;
                    }
                }
                
                for (var i = x + 1; i < xMax; i++)
                {
                    if (map[y, i] >= map[y, x])
                    {
                        blockedTree.Add($"{y}-{x}");
                        
                        break;
                    }
                }

                if (blockedTree.Count() == 4)
                {
                    blockedTrees.Add(blockedTree.First());
                }
            }
        }

        return xMax * yMax - blockedTrees.Count;
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