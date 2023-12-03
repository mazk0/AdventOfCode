namespace AoC2023;

public static class ArrayHelpers
{
    public static string[] ToPaddedData(this string[] data, char padding)
    {
        var stringLenght = data.OrderByDescending(s => s.Length).First().Length;
        var paddedData = new List<string>();
        paddedData.Add(new string(padding, stringLenght + 2));
        paddedData.AddRange(data.Select(row => $".{row}."));
        paddedData.Add(new string(padding, stringLenght + 2));

        return paddedData.ToArray();
    }
}