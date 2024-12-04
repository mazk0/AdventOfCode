using AoC2024.Four;
using AoC2024.One;
using AoC2024.Three;
using AoC2024.Two;

const string baseDataPath = "/Users/mazk0/Developer/AdventOfCode/Data2024";

Console.WriteLine("Day one");
var dayOneDataFilePath = $"{baseDataPath}/DayOneData.txt";

Console.WriteLine(nameof(OneOne));
Console.WriteLine($"Was: {OneOne.Run(dayOneDataFilePath)} Should be: 2264607");
Console.WriteLine("---");
Console.WriteLine(nameof(OneTwo));
Console.WriteLine($"Was: {OneTwo.Run(dayOneDataFilePath)} Should be: 19457120");

Console.WriteLine("Day two");
var dayTwoDataFilePath = $"{baseDataPath}/DayTwoData.txt";

Console.WriteLine(nameof(TwoOne));
Console.WriteLine($"Was: {TwoOne.Run(dayTwoDataFilePath)} Should be: 564");
Console.WriteLine("---");
Console.WriteLine(nameof(TwoTwo));
Console.WriteLine($"Was: {TwoTwo.Run(dayTwoDataFilePath)} Should be: 604");

Console.WriteLine("Day three");
var dayThreeDataFilePath = $"{baseDataPath}/DayThreeData.txt";

Console.WriteLine(nameof(ThreeOne));
Console.WriteLine($"Was: {ThreeOne.Run(dayThreeDataFilePath)} Should be: 173785482");
Console.WriteLine("---");
Console.WriteLine(nameof(ThreeTwo));
Console.WriteLine($"Was: {ThreeTwo.Run(dayThreeDataFilePath)} Should be: 83158140");

Console.WriteLine("Day four");
var dayFourDataFilePath = $"{baseDataPath}/DayFourData.txt";

Console.WriteLine(nameof(FourOne));
Console.WriteLine($"Was: {FourOne.Run(dayFourDataFilePath)} Should be: 2468");
Console.WriteLine("---");
Console.WriteLine(nameof(FourTwo));
Console.WriteLine($"Was: {FourTwo.Run(dayFourDataFilePath)} Should be: 1864");
