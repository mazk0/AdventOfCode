namespace AoC2024.Nine;

public static class NineOne
{
    public static long Run(string dataFilepath)
    {
        long checkSum = 0;
        
        foreach (var dataRow in File.ReadLines(dataFilepath))
        {
            var numbers = dataRow.Select(c => int.Parse(c.ToString())).ToArray();
            var fragmentedDataRow = new List<int>();
            var isFile = true;
            var fileId = 0;
            
            foreach (var number in numbers)
            {
                if (isFile)
                {
                    fragmentedDataRow.AddRange(Enumerable.Repeat(fileId, number).ToArray());
                    fileId++;
                }
                else
                {
                    fragmentedDataRow.AddRange(Enumerable.Repeat(-1, number).ToArray());
                }
                isFile = !isFile;
            }


            var defragmentedDataRow = new long[fragmentedDataRow.Count];
            Array.Fill(defragmentedDataRow, -1);
            Array.Fill(defragmentedDataRow, 0, 0, numbers[0]);
            var insertIndex = numbers[0];

            for (var j = fragmentedDataRow.Count - 1; j >= 0; j--)
            {
                var number = fragmentedDataRow[j];
                
                if (number == -1) continue;

                if (fragmentedDataRow[insertIndex] == -2) break;

                for (var i = insertIndex; i < fragmentedDataRow.Count; i++)
                {
                    if (fragmentedDataRow[insertIndex] == -2) break;

                    if (fragmentedDataRow[i] != -1)
                    {
                        defragmentedDataRow[insertIndex] = fragmentedDataRow[i];
                        insertIndex++;
                        continue;
                    }

                    defragmentedDataRow[insertIndex] = number;
                    fragmentedDataRow[j] = -2;
                    insertIndex++;
                    break;
                }
            }

            checkSum = defragmentedDataRow
                .TakeWhile(t => t != -1)
                .Select((t, i) => i * t)
                .Sum();
        }

        return checkSum;
    }
}