using AoC2023.Five;
using AoC2023.Four;
using AoC2023.One;
using AoC2023.Six;
using AoC2023.Three;
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

Console.WriteLine("Day two");
var dayTwoDataFilePath = $"{baseDataPath}/DayTwoData.txt";

Console.WriteLine(nameof(TwoOne));
Console.WriteLine(TwoOne.Run(dayTwoDataFilePath));
Console.WriteLine("---");
Console.WriteLine(nameof(TwoTwo));
Console.WriteLine(TwoTwo.Run(dayTwoDataFilePath));

Console.WriteLine("-----");

Console.WriteLine("Day three");
var dayThreeDataFilePath = $"{baseDataPath}/DayThreeData.txt";

Console.WriteLine(nameof(ThreeOne));
Console.WriteLine(ThreeOne.Run(dayThreeDataFilePath));
Console.WriteLine("---");
Console.WriteLine(nameof(ThreeTwo));
Console.WriteLine(ThreeTwo.Run(dayThreeDataFilePath));

Console.WriteLine("-----");

Console.WriteLine("Day four");
var dayFourDataFilePath = $"{baseDataPath}/DayFourData.txt";

Console.WriteLine(nameof(FourOne));
Console.WriteLine(FourOne.Run(dayFourDataFilePath));
Console.WriteLine("---");
Console.WriteLine(nameof(FourTwo));
Console.WriteLine(FourTwo.Run(dayFourDataFilePath));

Console.WriteLine("-----");

Console.WriteLine("Day five");
var dayFiveDataFilePath = $"{baseDataPath}/DayFiveData.txt";

Console.WriteLine(nameof(FiveOne));
Console.WriteLine(FiveOne.Run(dayFiveDataFilePath));
Console.WriteLine("---");
Console.WriteLine(nameof(FiveTwo));
Console.WriteLine(FiveTwo.Run(dayFiveDataFilePath));

Console.WriteLine("-----");

Console.WriteLine("Day six");
var daySixDataFilePath = $"{baseDataPath}/DaySixData.txt";

Console.WriteLine(nameof(SixOne));
Console.WriteLine(SixOne.Run(daySixDataFilePath));
Console.WriteLine("---");
Console.WriteLine(nameof(SixTwo));
Console.WriteLine(SixTwo.Run(daySixDataFilePath));