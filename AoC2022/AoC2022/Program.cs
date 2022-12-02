using AoC2022.One;
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
