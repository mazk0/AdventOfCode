namespace AoC2022.Ten;

public static class TenTwo
{
    private static int _signalRow = 0;
    private static int _cycle = 0;
    
    public static int GetCapitalLettersOnTv(string dataFilepath)
    {
        var signal = new bool[6, 40];
        var X = 1;
        
        foreach (var row in File.ReadLines(dataFilepath))
        {
            var command = row.Split(' ');
            switch (command[0])
            {
                case "noop":
                    ProcessSignal(X, signal);
                    break;
                case "addx":
                {
                    ProcessSignal(X, signal);
                    ProcessSignal(X, signal);
                    X += int.Parse(command[1]);
                    break;
                }
            }
        }
        
        PrintResult(signal);

        return default;
    }

    private static void ProcessSignal(int X, bool[,] signal)
    {
        if (_cycle > 0 && _cycle % 40 == 0)
        {
            _signalRow++;
            _cycle = 0;
        }
        
        if (_cycle == X - 1 || _cycle == X || _cycle == X + 1)
        {
            signal[_signalRow, _cycle] = true;
        }

        _cycle++;
    }

    private static void PrintResult(bool[,] signal)
    {
        for (var i = 0; i < signal.GetLength(0); i++)
        {
            for (var j = 0; j < signal.GetLength(1); j++)
            {
                var onOrOff = signal[i, j] ? '#' : '.';
                Console.Write(onOrOff);
            }
            
            Console.Write(Environment.NewLine);
        }
    }
}