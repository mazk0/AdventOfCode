namespace AoC2022.Eight;

public static class NineOne
{
    public static int CalculateVisitedCount(string dataFilepath)
    {
        var visitedPlaces = new Dictionary<string, bool>();
        var currentXPosition = 0;
        var currentYPosition = 0;
        
        foreach (var row in File.ReadLines(dataFilepath))
        {
            var command = row.Split(' ');

            if (command[0] == "U")
            {
                currentXPosition += int.Parse(command[1]);
            }
            
            if (command[0] == "D")
            {
                currentXPosition -= int.Parse(command[1]);
            }
            
            if (command[0] == "R")
            {
                currentYPosition += int.Parse(command[1]);
            }
            
            if (command[0] == "L")
            {
                currentYPosition -= int.Parse(command[1]);
            }
            
            Console.WriteLine($"X Pos: {currentXPosition}");
            Console.WriteLine($"Y Pos: {currentYPosition}");
        }

        return default;
    }
}