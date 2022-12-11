namespace AoC2022.Nine;

public static class NineOne
{
    private static readonly Dictionary<string, int> _visitedPlaces = new() {{"0_0", 1}};
    private static int _headXPosition = 0;
    private static int _headYPosition = 0;
    private static int _tailXPosition = 0;
    private static int _tailYPosition = 0;
    
    public static int CalculateVisitedCount(string dataFilepath)
    {
        foreach (var row in File.ReadLines(dataFilepath))
        {
            var command = row.Split(' ');

            for (var i = 0; i < int.Parse(command[1]); i++)
            {
                MoveHead(command);

                MoveTail();
                
                SetVisitedLocations($"{_tailXPosition}_{_tailYPosition}");
            }
        }

        return _visitedPlaces.Count;
    }

    private static void MoveHead(IReadOnlyList<string> command)
    {
        switch (command[0])
        {
            case "U":
                _headYPosition++;
                break;
            case "D":
                _headYPosition--;
                break;
            case "L":
                _headXPosition--;
                break;
            case "R":
                _headXPosition++;
                break;
        }
    }
    
    private static void MoveTail()
    {
        if (Math.Abs(_headXPosition - _tailXPosition) <= 1 && Math.Abs(_headYPosition - _tailYPosition) <= 1)
        {
            return;
        }

        if (_headXPosition == _tailXPosition && _headYPosition != _tailYPosition)
        {
            _tailYPosition = _headYPosition > _tailYPosition ? _tailYPosition + 1 : _tailYPosition - 1;
            return;
        }

        if (_headYPosition == _tailYPosition && _headXPosition != _tailXPosition)
        {
            _tailXPosition = _headXPosition > _tailXPosition ? _tailXPosition + 1 : _tailXPosition - 1;
            return;
        }

        _tailYPosition = _headYPosition > _tailYPosition ? _tailYPosition + 1 : _tailYPosition - 1;
        _tailXPosition = _headXPosition > _tailXPosition ? _tailXPosition + 1 : _tailXPosition - 1;
    }

    private static void SetVisitedLocations(string address)
    {
        if (_visitedPlaces.TryGetValue(address, out var value))
        {
            value++;
            return;
        }

        _visitedPlaces.Add(address, 1);
    }
}