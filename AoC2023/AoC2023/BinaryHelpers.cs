namespace AoC2023;

public static class BinaryHelpers
{
    public static int ToBinaryNumberAt(this int position)
    {
        if (position == 0)
        {
            return 0;
        }
        
        var numbers = new List<int>();
        for (var i = 1; i <= position; i++)
        {
            switch (i)
            {
                case 1:
                    numbers.Add(1);
                    break;
                case 2:
                    numbers.Add(2);
                    break;
                default:
                    numbers.Add(numbers[i - 2] * 2);
                    break;
            }
        }

        return numbers[position - 1];
    }
}