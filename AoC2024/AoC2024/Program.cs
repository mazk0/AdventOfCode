using AoC2024.One;
using AoC2024.Two;

const string baseDataPath = "/Users/mazk0/Developer/AdventOfCode/Data2024";

Console.WriteLine("Day one");
var dayOneDataFilePath = $"{baseDataPath}/DayOneData.txt";

Console.WriteLine(nameof(OneOne));
// Console.WriteLine(OneOne.Run(dayOneDataFilePath));
Console.WriteLine("---");
Console.WriteLine(nameof(OneTwo));
// Console.WriteLine(OneTwo.Run(dayOneDataFilePath));

Console.WriteLine("Day two");
var dayTwoDataFilePath = $"{baseDataPath}/DayTwoData.txt";

Console.WriteLine(nameof(TwoOne));
Console.WriteLine(TwoOne.Run(dayTwoDataFilePath));
// Console.WriteLine("---");
// Console.WriteLine(nameof(OneTwo));
// Console.WriteLine(OneTwo.Run(dayOneDataFilePath));
