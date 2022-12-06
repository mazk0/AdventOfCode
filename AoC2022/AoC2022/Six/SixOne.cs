namespace AoC2022.Six;

public static class SixOne
{
    public static int GetMessageStartIndex(string dataFilepath, int makerLength)
    {
        var row = File.ReadLines(dataFilepath).Single();
        for (var index = 0; index < row.Length; index++)
        {
            var stringToValidate = row.Substring(index, makerLength);
            if (stringToValidate.Distinct().Count() == makerLength)
            {
                return index + makerLength;
            }
        }

        return default;
    }
}