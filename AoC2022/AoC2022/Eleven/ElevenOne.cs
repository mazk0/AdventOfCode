namespace AoC2022.Eleven;

public static class ElevenOne
{
    public static int GetLevelOfMonkeyBusiness(string dataFilepath)
    {
        
        var monkeys = LoadMonkeyData(dataFilepath);

        return default;
    }

    private static List<Monkey> LoadMonkeyData(string dataFilepath)
    {
        var monkeys = new List<Monkey>();
        var monkeyLoopIndex = 0;
        var currentMonkeyId = -1;
        foreach (var row in File.ReadLines(dataFilepath))
        {
            if (string.IsNullOrEmpty(row))
            {
                continue;
            }

            if (row.StartsWith("Monkey"))
            {
                monkeys.Add(new Monkey
                {
                    Id = int.Parse(row.Substring(7, 1))
                });

                currentMonkeyId++;
            }

            switch (monkeyLoopIndex)
            {
                case 1:
                    monkeys[currentMonkeyId].Items.AddRange(row[(row.IndexOf(": ") + 2)..].Split(", ").Select(int.Parse));
                    break;
                case 2:
                {
                    var spaceIndex = row.LastIndexOf(' ');
                    monkeys[currentMonkeyId].OperationType = row.Substring(spaceIndex - 1, 1);

                    if (int.TryParse(row[(spaceIndex + 1)..], out var modifier))
                    {
                        monkeys[currentMonkeyId].OperationModifier = modifier;
                    }
                    else
                    {
                        monkeys[currentMonkeyId].ModifierTargetSelf = true;
                    }

                    break;
                }
                case 3:
                    monkeys[currentMonkeyId].TestDivider = int.Parse(row[(row.LastIndexOf(' ') + 1)..]);
                    break;
                case 4:
                    monkeys[currentMonkeyId].TargetTrue = int.Parse(row[(row.LastIndexOf(' ') + 1)..]);
                    break;
                case 5:
                    monkeys[currentMonkeyId].TargetFalse = int.Parse(row[(row.LastIndexOf(' ') + 1)..]);
                    break;
            }

            if (monkeyLoopIndex == 5)
            {
                monkeyLoopIndex = 0;
            }
            else
            {
                monkeyLoopIndex++;
            }
        }

        return monkeys;
    }
}

public class Monkey
{
    public int Id { get; set; }
    public List<int> Items { get; } = new();
    public string OperationType { get; set; }
    public int OperationModifier { get; set; }
    public int TestDivider { get; set; }
    public int TargetTrue { get; set; }
    public int TargetFalse { get; set; }
    public bool ModifierTargetSelf { get; set; }
}