namespace AoC2023.Eleven;

public static class ElevenOne
{
    public static int Run(string dataFilepath)
    {
        var maxValue = 0;
        var data = File.ReadLines(dataFilepath).Select(dataRow => dataRow.ToCharArray().ToList()).ToList();
        var blankRows = GetBlankRows(data);
        var blankCols = GetBlankColumns(data);
        var map = GetStarMap(data);
        
        
        for (var i = 0; i < map.Count; i++)
        {
            var p1 = map[i];
            for (var j = i + 1; j < map.Count; j++)
            {
                var p2 = map[j];

                var steps = Math.Abs(p1.column - p2.column) + Math.Abs(p1.row - p2.row);
                steps += blankRows.Count(x => p1.row < x && x < p2.row || p2.row < x && x < p1.row);
                steps += blankCols.Count(x => p1.column < x && x < p2.column || p2.column < x && x < p1.column);
                
                maxValue += steps;
            }
        }
        
        return maxValue;
    }

    private static List<(int row, int column)> GetStarMap(List<List<char>> data)
    {
        var map = new List<(int row, int column)>();
        for (var row = 0; row < data.Count; row++)
        {
            for (var column = 0; column < data[row].Count; column++)
            {
                if (data[row][column] == '#')
                {
                    map.Add((row, column));
                }
            }
        }

        return map;
    }

    private static List<int> GetBlankRows(List<List<char>> data)
    {
        var blankRows = new List<int>();
        for (var i = 0; i < data.Count; i++)
        {
            if (data[i].All(x => x == '.'))
            {
                blankRows.Add(i);
            }
        }

        return blankRows;
    }
    
    private static List<int> GetBlankColumns(List<List<char>> data)
    {
        var blankCols = new List<int>();
        for (var i = 0; i < data[0].Count; i++)
        {
            var allBlank = true;
            foreach (var t in data.Where(t => t[i] != '.'))
            {
                allBlank = false;
            }

            if (allBlank)
            {
                blankCols.Add(i);
            }
        }
        
        return blankCols;
    }
}