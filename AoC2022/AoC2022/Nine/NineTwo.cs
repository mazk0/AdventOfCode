namespace AoC2022.Nine;

public static class NineTwo
{
    private static readonly Dictionary<string, int>[] _visitedPlaces = new Dictionary<string, int>[10];
    private static readonly List<Address> _addresses = new();

    public static int CalculateVisitedCount(string dataFilepath)
    {
        for (var i = 0; i < 10; i++)
        {
            _visitedPlaces[i] = new Dictionary<string, int>{{"0_0", 1}};
            _addresses.Add(new Address{X = 0, Y = 0});
        }
        
        foreach (var row in File.ReadLines(dataFilepath))
        {
            var command = row.Split(' ');

            for (var i = 0; i < int.Parse(command[1]); i++)
            {
                for (var j = 0; j < _addresses.Count - 1; j++)
                {
                    var headAddress = _addresses[j];
                    var tailAddress = _addresses[j + 1];
                    
                    // Only move head once.
                    if (j == 0)
                    {
                        MoveHead(command, headAddress);
                    }
                    MoveTail(headAddress, tailAddress);

                    SetVisitedLocations(_visitedPlaces[j], $"{tailAddress.X}_{tailAddress.Y}");
                }
            }
        }
        
        return _visitedPlaces[^2].Count;
    }

    private static void MoveHead(IReadOnlyList<string> command, Address address)
    {
        switch (command[0])
        {
            case "U":
                address.Y++;
                break;
            case "D":
                address.Y--;
                break;
            case "L":
                address.X--;
                break;
            case "R":
                address.X++;
                break;
        }
    }
    
    private static void MoveTail(Address head, Address tail)
    {
        if (Math.Abs(head.X - tail.X) <= 1 && Math.Abs(head.Y - tail.Y) <= 1)
        {
            return;
        }

        if (head.X == tail.X && head.Y != tail.Y)
        {
            tail.Y = head.Y > tail.Y ? tail.Y + 1 : tail.Y - 1;
            return;
        }

        if (head.Y == tail.Y && head.X != tail.X)
        {
            tail.X = head.X > tail.X ? tail.X + 1 : tail.X - 1;
            return;
        }

        tail.Y = head.Y > tail.Y ? tail.Y + 1 : tail.Y - 1;
        tail.X = head.X > tail.X ? tail.X + 1 : tail.X - 1;
    }

    private static void SetVisitedLocations(IDictionary<string, int> visitedPlace, string address)
    {
        if (visitedPlace.TryGetValue(address, out var value))
        {
            value++;
            return;
        }

        visitedPlace.Add(address, 1);
    }
}

public class Address
{
    public int X { get; set; }
    public int Y { get; set; }
}