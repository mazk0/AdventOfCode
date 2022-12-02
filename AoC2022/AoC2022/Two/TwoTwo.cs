namespace AoC2022.Two;

public static class TwoTwo
{
    public static int SimulateTournament(string dataFilepath)
    {
        var score = 0;

        foreach (var (opponent, me) in File.ReadLines(dataFilepath).Select(GetScoredHits))
        {
            if (me == 1)
            {
                if (opponent == 1)
                {
                    score += 3;
                }
                else
                {
                    score += opponent - 1;
                }

                continue;
            }
            
            if (me == 2)
            {
                score += opponent + 3;
                
                continue;
            }
            
            if (me == 3)
            {
                if (opponent == 3)
                {
                    score += 7;
                }
                else
                {
                    score += opponent + 1 + 6;
                }
            }
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