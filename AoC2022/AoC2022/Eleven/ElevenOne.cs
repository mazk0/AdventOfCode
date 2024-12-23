namespace AoC2022.Eleven;

public static class ElevenOne
{
    public static int GetLevelOfMonkeyBusiness(string dataFilepath)
    {
        var monkeys = LoadMonkeyData(dataFilepath);

        for (var index = 0; index < 20; index++)
        {
            foreach (var monkey in monkeys)
            {
                var items = monkey.Items;
                ProcessItems(items, monkey);

                TransferItems(items, monkey, monkeys);

                items.Clear();
            }
        }

        return monkeys
            .Select(monkey => monkey.InspectedItemCount)
            .OrderDescending()
            .Take(2)
            .Aggregate((x, y) => x * y);
    }
    
    private static void ProcessItems(IList<long> items, Monkey monkey)
    {
        for (var index = 0; index < items.Count; index++)
        {
            monkey.InspectedItemCount++;

            switch (monkey)
            {
                case {ModifierTargetSelf: true, OperationType: "*"}:
                    items[index] *= items[index];
                    break;
                case {ModifierTargetSelf: true, OperationType: "+"}:
                    items[index] += items[index];
                    break;
                case {ModifierTargetSelf: false, OperationType: "*"}:
                    items[index] *= monkey.OperationModifier;
                    break;
                case {ModifierTargetSelf: false, OperationType: "+"}:
                    items[index] += monkey.OperationModifier;
                    break;
            }
        }
    }
    
    private static void TransferItems(IEnumerable<long> items, Monkey monkey, IReadOnlyList<Monkey> monkeys)
    {
        foreach (var dividedItem in items.Select(item => item / 3))
        {
            if (dividedItem % monkey.TestDivider == 0)
            {
                monkeys[monkey.TargetTrue].Items.Add(dividedItem);
            }
            else
            {
                monkeys[monkey.TargetFalse].Items.Add(dividedItem);
            }
        }
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
                    monkeys[currentMonkeyId].Items.AddRange(row[(row.IndexOf(": ") + 2)..].Split(", ").Select(long.Parse));
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