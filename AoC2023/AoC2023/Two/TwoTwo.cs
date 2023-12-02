namespace AoC2023.Two;

public static class TwoTwo
{
    public static int Run(string dataFilepath)
    {
        var maxValue = 0;
        foreach (var dataRow in File.ReadLines(dataFilepath))
        {
            var game = dataRow.Split(':');
            var rounds = game[1].Split(';');
            var maxRed = 0;
            var maxGreen = 0;
            var maxBlue = 0;

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
                        case "red" when number > maxRed:
                            maxRed = number;
                            continue;
                        case "green" when number > maxGreen:
                            maxGreen = number;
                            continue;
                        case "blue" when number > maxBlue:
                            maxBlue = number;
                            continue;
                    }
                }
            }
            
            maxValue += maxRed * maxGreen * maxBlue;
        }

        return maxValue;
    }
}