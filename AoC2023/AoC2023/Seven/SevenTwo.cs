namespace AoC2023.Seven;

public static class SevenTwo
{
    public static int Run(string dataFilepath)
    {
        var hands = File.ReadLines(dataFilepath).Select(dataRow => dataRow.Split(' ')).Select(parts => new HandTwo {Cards = parts[0], Wins = int.Parse(parts[1])}).ToList();
        var orderedHands = hands.OrderBy(x => x.Cards, new CardsComparerTwo()).ToList();

        var score = 0;
        for (var i = 1; i < orderedHands.Count + 1; i++)
        {
            score += orderedHands[i - 1].Wins * i;
        }
        
        return score;
    }
}

public class CardsComparerTwo : IComparer<string>
{
    public int Compare(string? x, string? y)
    {
        var strengthX = GetHandStrength(x);
        var strengthY = GetHandStrength(y);

        if (strengthX > strengthY)
        {
            return 1;
        }

        if (strengthX < strengthY)
        {
            return -1;
        }
        
        for (var i = 0; i < 5; i++)
        {
            var comparedResult = StrongerCardsCheck(x[i], y[i]);
            if (comparedResult != 0)
            {
                return comparedResult;
            }
        }
        
        return 0;
    }

    private static int StrongerCardsCheck(char x, char y)
    {
        const string strengthIndex = "AKQT98765432J";

        var indexOfX = strengthIndex.IndexOf(x, StringComparison.OrdinalIgnoreCase);
        var indexOfY = strengthIndex.IndexOf(y, StringComparison.OrdinalIgnoreCase);

        if (indexOfX < indexOfY)
        {
            return 1;
        }
        
        if (indexOfX > indexOfY)
        {
            return -1;
        }
        
        return 0;
    }

    private static int GetHandStrength(string hand)
    {
        var grouping = hand.GroupBy(x => x).ToList();
        var jLessMax = grouping.Where(x => x.Key != 'J').MaxBy(x => x.Count())?.Key;
        if (jLessMax != null)
        {
            hand = hand.Replace('J', jLessMax.Value);
        }
        grouping = hand.GroupBy(x => x).ToList();
        var max = grouping.Max(x => x.Count());

        switch (max)
        {
            case 5:
                return 7;
            case 4:
                return 6;
            case 3:
                return grouping.Any(f => f.Count() == 2) ? 5 : 4;
            case 2:
                return grouping.Count(f => f.Count() == 2) == 2 ? 3 : 2;
            default:
                return 1;
        }
    }
}

public class HandTwo
{
    public string Cards { get; set; }
    public int Wins { get; set; }
}
