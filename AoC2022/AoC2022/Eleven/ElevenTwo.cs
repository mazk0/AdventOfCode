namespace AoC2022.Eleven;

public static class ElevenTwo
{
    public static long GetLevelOfMonkeyBusiness(string dataFilepath)
    {
        var monkeys = LoadMonkeyData(dataFilepath);
        var leastCommonMultiple = monkeys.Select(monkey => monkey.TestDivider).Aggregate((a, b) => a * b);

        for (var index = 0; index < 10000; index++)
        {
            foreach (var monkey in monkeys)
            {
                var items = monkey.Items;
                ProcessItems(items, monkey);

                TransferItems(items, monkey, monkeys, leastCommonMultiple);

                items.Clear();
            }
        }

        var monkeyBusiness = monkeys
            .Select(monkey => monkey.InspectedItemCount)
            .OrderDescending()
            .Take(2);

        return Convert.ToInt64(monkeyBusiness.First()) * Convert.ToInt64(monkeyBusiness.Last());
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
    
    private static void TransferItems(IEnumerable<long> items, Monkey monkey, IReadOnlyList<Monkey> monkeys, int leastCommonMultiple)
    {
        foreach (var item in items.Select(item => item % leastCommonMultiple))
        {
            if (item % monkey.TestDivider == 0)
            {
                monkeys[monkey.TargetTrue].Items.Add(item);
            }
            else
            {
                monkeys[monkey.TargetFalse].Items.Add(item);
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