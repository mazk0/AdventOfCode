using AoC2022.Five;
using AoC2022.Four;
using AoC2022.One;
using AoC2022.Six;
using AoC2022.Three;
using AoC2022.Two;

Console.WriteLine("Day one");
const string dayOneDataFilePath = "/workspaces/AdventOfCode/Data2022/DayOneData.txt";

Console.WriteLine(nameof(OneOne));
Console.WriteLine(OneOne.GetMaxTotalCalories(dayOneDataFilePath));
Console.WriteLine("---");
Console.WriteLine(nameof(OneTwo));
Console.WriteLine(OneTwo.GetMaxTotalCaloriesForTopThree(dayOneDataFilePath));

Console.WriteLine("-----");

Console.WriteLine("Day two");
const string dayTwoDataFilePath = "/workspaces/AdventOfCode/Data2022/DayTwoData.txt";

Console.WriteLine(nameof(TwoOne));
Console.WriteLine(TwoOne.SimulateTournament(dayTwoDataFilePath));
Console.WriteLine("---");
Console.WriteLine(nameof(TwoTwo));
Console.WriteLine(TwoTwo.SimulateTournament(dayTwoDataFilePath));

Console.WriteLine("-----");

Console.WriteLine("Day three");
const string dayThreeDataFilePath = "/workspaces/AdventOfCode/Data2022/DayThreeData.txt";

Console.WriteLine(nameof(ThreeOne));
Console.WriteLine(ThreeOne.GetPrioritySum(dayThreeDataFilePath));
Console.WriteLine("---");
Console.WriteLine(nameof(ThreeTwo));
Console.WriteLine(ThreeTwo.GetPrioritySum(dayThreeDataFilePath));

Console.WriteLine("-----");

Console.WriteLine("Day four");
const string dayFourDataFilePath = "/workspaces/AdventOfCode/Data2022/DayFourData.txt";

Console.WriteLine(nameof(FourOne));
Console.WriteLine(FourOne.GetOverlappingRangeCount(dayFourDataFilePath));
Console.WriteLine("---");
Console.WriteLine(nameof(FourTwo));
Console.WriteLine(FourTwo.GetOverlappingRangeCount(dayFourDataFilePath));

Console.WriteLine("-----");

Console.WriteLine("Day five");
const string dayFiveDataFilePath = "/workspaces/AdventOfCode/Data2022/DayFiveData.txt";

Console.WriteLine(nameof(FiveOne));
Console.WriteLine(FiveOne.GetSupplyStacks(dayFiveDataFilePath));
Console.WriteLine("---");
Console.WriteLine(nameof(FiveTwo));
Console.WriteLine(FiveTwo.GetSupplyStacks(dayFiveDataFilePath));

Console.WriteLine("-----");
Console.WriteLine("Day six");
const string daySixDataFilePath = "/workspaces/AdventOfCode/Data2022/DaySixData.txt";

Console.WriteLine(nameof(SixOne));
Console.WriteLine(SixOne.GetMessageStartIndex(daySixDataFilePath, 4));
Console.WriteLine("---");
Console.WriteLine("SixTwo");
Console.WriteLine(SixOne.GetMessageStartIndex(daySixDataFilePath, 14));

Console.WriteLine("-----");

