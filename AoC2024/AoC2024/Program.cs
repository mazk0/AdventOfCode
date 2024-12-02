using AoC2024.One;
using AoC2024.Two;

const string baseDataPath = "/Users/mazk0/Developer/AdventOfCode/Data2024";

Console.WriteLine("Day one");
var dayOneDataFilePath = $"{baseDataPath}/DayOneData.txt";

Console.WriteLine(nameof(OneOne));
Console.WriteLine($"Was: {OneOne.Run(dayOneDataFilePath)} Should be: ?");
Console.WriteLine("---");
Console.WriteLine(nameof(OneTwo));
Console.WriteLine($"Was: {OneTwo.Run(dayOneDataFilePath)} Should be: ?");

Console.WriteLine("Day two");
var dayTwoDataFilePath = $"{baseDataPath}/DayTwoData.txt";

Console.WriteLine(nameof(TwoOne));
Console.WriteLine($"Was: {TwoOne.Run(dayTwoDataFilePath)} Should be: 564");
Console.WriteLine("---");
Console.WriteLine(nameof(TwoTwo));
Console.WriteLine($"Was: {TwoTwo.Run(dayTwoDataFilePath)} Should be: 604");
