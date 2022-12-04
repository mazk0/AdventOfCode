namespace AoC2022.Four;

public static class FourOne
{
    public static int GetOverlappingRangeCount(string dataFilepath)
    {
        var overLappedRangeCount = 0;

        foreach (var row in File.ReadLines(dataFilepath))
        {
            var parts = row.Split(',');
            var leftPart = parts.First().Split('-');
            var leftPartMinIndex = Convert.ToInt32(leftPart.First());
            var leftPartMaxIndex = Convert.ToInt32(leftPart.Last());
            var rightPart = parts.Last().Split('-');
            var rightPartMinIndex = Convert.ToInt32(rightPart.First());
            var rightPartMaxIndex = Convert.ToInt32(rightPart.Last());

            if (leftPartMinIndex >= rightPartMinIndex && leftPartMaxIndex <= rightPartMaxIndex)
            {
                overLappedRangeCount++;
                continue;
            }

            if (leftPartMinIndex <= rightPartMinIndex && leftPartMaxIndex >= rightPartMaxIndex)
            {
                overLappedRangeCount++;
            }
        }
        
        return overLappedRangeCount;
    }
}