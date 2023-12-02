namespace AoC2023.Two;

public static class TwoOne
{
    public static int Run(string dataFilepath)
    {
        var maxValue = 0;
        foreach (var dataRow in File.ReadLines(dataFilepath))
        {
            var game = dataRow.Split(':');
            var rounds = game[1].Split(';');
            var isPossible = true;
            foreach (var round in rounds)
            {
                var scores = round.Trim().Split(' ');
                for (var i = 0; i < scores.Length / 2; i++)
                {
                    var score = scores.Skip(2 * i).Take(2).ToArray();
                    var color = score[1].TrimEnd(',');
                    var number = int.Parse(score[0]);

                    switch (color)
                    {
                        case "red" when number > 12:
                        case "green" when number > 13:
                        case "blue" when number > 14:
                            isPossible = false;
                            break;
                    }
                }
            }
            
            if (isPossible)
            {
                maxValue += int.Parse(game[0].Split(' ')[1]);
            }
        }

        return maxValue;
    }
}