namespace AoC2022.Six;

public static class SixOne
{
    public static int GetSupplyStacks(string dataFilepath)
    {
        const int makerLength = 4;
        var row = File.ReadLines(dataFilepath).Single();
        for (var index = 0; index < row.Length; index++)
        {
            var stringToValidate = row.Substring(index, makerLength);
            if (stringToValidate.Distinct().Count() == makerLength)
            {
                return index + 4;
            }
        }

        return 0;
    }
}