namespace AoC2022.Six;

public static class SixOne
{
    public static int GetMessageStartIndex(string dataFilepath, int markerLength)
    {
        var row = File.ReadLines(dataFilepath).Single();
        for (var index = 0; index < row.Length; index++)
        {
            var stringToValidate = row.Substring(index, markerLength);
            if (stringToValidate.Distinct().Count() == markerLength)
            {
                return index + markerLength;
            }
        }

        return default;
    }
}