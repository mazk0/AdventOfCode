using AoC2023.One;
using AoC2023.Two;

const string baseDataPath = "/Users/mazk0/Developer/AdventOfCode/Data2023";

Console.WriteLine("Day one");
var dayOneDataFilePath = $"{baseDataPath}/DayOneData.txt";

Console.WriteLine(nameof(OneOne));
Console.WriteLine(OneOne.Run(dayOneDataFilePath));
Console.WriteLine("---");
Console.WriteLine(nameof(OneTwo));
Console.WriteLine(OneTwo.Run(dayOneDataFilePath));

Console.WriteLine("-----");

Console.WriteLine("Day one");
var dayTwoDataFilePath = $"{baseDataPath}/DayTwoData.txt";

Console.WriteLine(nameof(TwoOne));
Console.WriteLine(TwoOne.Run(dayTwoDataFilePath));
Console.WriteLine("---");
Console.WriteLine(nameof(TwoTwo));
Console.WriteLine(TwoTwo.Run(dayTwoDataFilePath));

Console.WriteLine("-----");