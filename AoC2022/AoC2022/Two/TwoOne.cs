namespace AoC2022.Two;

public static class TwoOne
{
    public static int SimulateTournament(string dataFilepath)
    {
        var score = 0;

        foreach (var (opponent, me) in File.ReadLines(dataFilepath).Select(GetScoredHits))
        {
            if (opponent == me)
            {
                score += 3 + me;
                continue;
            }

            if (opponent == 1 && me == 2)
            {
                score += 6 + me;
                continue;
            }
            
            if (opponent == 2 && me == 3)
            {
                score += 6 + me;
                continue;
            }
            
            if (opponent == 3 && me == 1)
            {
                score += 6 + me;
                continue;
            }

            score += me;
        }
        
        return score;
    }

    private static (int opponent, int me) GetScoredHits(string round)
    {
        var hits = round.Split(' ');
        var opponent = hits.First();
        var me = hits.Last();

        return (ScoreTheHit(opponent), ScoreTheHit(me));
    }

    private static int ScoreTheHit(string hit)
    {
        switch (hit)
        {
            case "A":
            case "X":
                return 1;
            case "B":
            case "Y":
                return 2;
            case "C":
            case "Z":
                return 3;
        }

        throw new FormatException($"Non supported character passed {hit}");
    }
}