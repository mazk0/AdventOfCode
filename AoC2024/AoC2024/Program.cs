using AoC2024.One;

const string baseDataPath = "/Users/mazk0/Developer/AdventOfCode/Data2024";

Console.WriteLine("Day one");
var dayOneDataFilePath = $"{baseDataPath}/DayOneData.txt";

Console.WriteLine(nameof(OneOne));
Console.WriteLine(OneOne.Run(dayOneDataFilePath));
Console.WriteLine("---");
Console.WriteLine(nameof(OneTwo));
Console.WriteLine(OneTwo.Run(dayOneDataFilePath));