namespace AoC2023.Four;

public static class FourTwo
{
    public static int Run(string dataFilepath)
    {
        var data = File.ReadAllLines(dataFilepath);
        var cardsCount = new Dictionary<int, int>();
        for (var i = 1; i < data.Length + 1; i++)
        {
            cardsCount.Add(i, 1);
        }
        
        foreach (var dataRow in data)
        {
            var card = dataRow.Split(": ");
            var gameId = int.Parse(card[0].Split(" ").Last());
            var game = card[1].Split(" | ");
            var winning = game[0].Split(" ");
            var row = game[1].Split(" ");

            var count = row.Where(x => winning.Contains(x) && x != "").Count();

            for (var i = 0; i < count; i++)
            {
                cardsCount[gameId + i + 1] += cardsCount[gameId];
            }
        }
        
        return cardsCount.Values.Sum();;
    }
}