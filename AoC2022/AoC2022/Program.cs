using AoC2022.Five;
using AoC2022.Four;
using AoC2022.One;
using AoC2022.Six;
using AoC2022.Three;
using AoC2022.Two;

Console.WriteLine("Day one");
const string dayOneDataFilePath = "/workspaces/AdventOfCode/Data2022/DayOneData.txt";

Console.WriteLine("OneOne");
Console.WriteLine(OneOne.GetMaxTotalCalories(dayOneDataFilePath));

Console.WriteLine("---");
Console.WriteLine("OneTwo");
Console.WriteLine(OneTwo.GetMaxTotalCaloriesForTopThree(dayOneDataFilePath));

Console.WriteLine("-----");
Console.WriteLine("Day two");
const string dayTwoDataFilePath = "/workspaces/AdventOfCode/Data2022/DayTwoData.txt";

Console.WriteLine("TwoOne");
Console.WriteLine(TwoOne.SimulateTournament(dayTwoDataFilePath));

Console.WriteLine("---");
Console.WriteLine("TwoOne");
Console.WriteLine(TwoTwo.SimulateTournament(dayTwoDataFilePath));

Console.WriteLine("-----");
Console.WriteLine("Day three");
const string dayThreeDataFilePath = "/workspaces/AdventOfCode/Data2022/DayThreeData.txt";

Console.WriteLine("ThreeOne");
Console.WriteLine(ThreeOne.GetPrioritySum(dayThreeDataFilePath));

Console.WriteLine("---");
Console.WriteLine("ThreeTwo");
Console.WriteLine(ThreeTwo.GetPrioritySum(dayThreeDataFilePath));

Console.WriteLine("-----");
Console.WriteLine("Day four");
const string dayFourDataFilePath = "/workspaces/AdventOfCode/Data2022/DayFourData.txt";

Console.WriteLine("FourOne");
Console.WriteLine(FourOne.GetOverlappingRangeCount(dayFourDataFilePath));

Console.WriteLine("---");
Console.WriteLine("FourTwo");
Console.WriteLine(FourTwo.GetOverlappingRangeCount(dayFourDataFilePath));

Console.WriteLine("-----");
Console.WriteLine("Day five");
const string dayFiveDataFilePath = "/workspaces/AdventOfCode/Data2022/DayFiveData.txt";

Console.WriteLine("FiveOne");
Console.WriteLine(FiveOne.GetSupplyStacks(dayFiveDataFilePath));
Console.WriteLine("---");
Console.WriteLine("FiveTwo");
Console.WriteLine(FiveTwo.GetSupplyStacks(dayFiveDataFilePath));

Console.WriteLine("-----");
Console.WriteLine("Day six");
const string daySixDataFilePath = "/workspaces/AdventOfCode/Data2022/DaySixData.txt";

Console.WriteLine("SixOne");
Console.WriteLine(SixOne.GetSupplyStacks(daySixDataFilePath));
Console.WriteLine("---");

Console.WriteLine("-----");

