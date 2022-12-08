namespace AoC2022.Seven;

public static class SevenTwo
{
    public static int SizeOfFolderToDelete(string dataFilepath)
    {
        var directoriesAndSize = new Dictionary<string, int>();
        var currentDirectory = new Stack<string>();
        var countedFiles = new List<string>();
        foreach (var row in File.ReadLines(dataFilepath))
        {
            CreateKey(directoriesAndSize, currentDirectory, row);
            GoDownOneDirectory(currentDirectory, row);
            GoUpOneDirectory(currentDirectory, directoriesAndSize, row);
            StoreFileSizeInDirectory(directoriesAndSize, currentDirectory, countedFiles, row);
        }
        
        return CalculateSizeOfFolderToDelete(directoriesAndSize);
    }

    private static void CreateKey(IDictionary<string, int> foldersAndSize, Stack<string> currentDir, string row)
    {
        if (row.Contains("$ cd") && !row.Contains("$ cd ..") && currentDir.Count == 0)
        {
            foldersAndSize.Add(row[(row.LastIndexOf(' ') + 1)..], default);
            
            return;
        }
        
        if (row.Contains("$ cd") && !row.Contains("$ cd ..") && !foldersAndSize.ContainsKey($"{currentDir.Peek()}_{row[(row.LastIndexOf(' ') + 1)..]}"))
        {
            foldersAndSize.Add($"{currentDir.Peek()}_{row[(row.LastIndexOf(' ') + 1)..]}", default);
        }
    }
    
    private static void GoDownOneDirectory(Stack<string> currentDir, string row)
    {
        if (row.Contains("$ cd") && !row.Contains("$ cd ..") && currentDir.Count == 0)
        {
            currentDir.Push(row[(row.LastIndexOf(' ') + 1)..]);
            
            return;
        }
        
        if (row.Contains("$ cd") && !row.Contains("$ cd ..") && currentDir.Count > 0)
        {
            currentDir.Push($"{currentDir.Peek()}_{row[(row.LastIndexOf(' ') + 1)..]}");
        }
    }
    
    private static void GoUpOneDirectory(Stack<string> currentDir, IDictionary<string, int> foldersAndSize, string row)
    {
        if (row.Contains("$ cd .."))
        {
            var previousDir = currentDir.Pop();
            foldersAndSize[currentDir.Peek()] += foldersAndSize[previousDir];
        }
    }
    
    private static void StoreFileSizeInDirectory(IDictionary<string, int> foldersAndSize, Stack<string> currentDir, List<string> countedFiles, string row)
    {
        if (!int.TryParse(row[..row.IndexOf(' ')], out var number))
        {
            return;
        }

        foldersAndSize[currentDir.Peek()] += number;
    }
    
    private static int CalculateSizeOfFolderToDelete(Dictionary<string, int> directoriesAndSize)
    {
        return directoriesAndSize.Values
            .Where(value => value > directoriesAndSize["/"] - (70000000 - 30000000))
            .OrderBy(value => value)
            .First();
    }
}