using System.IO;


public static class UniquePathUtility
{
    public static string CreateUniqueName(string path, string name)
    {
        string firstPath = Path.Combine(path, string.Format("{0}.json", name));
        string nextPath = firstPath;
        int index = 1;
        while (File.Exists(nextPath) || Directory.Exists(nextPath))
        {
            nextPath = Path.Combine(path, string.Format("{0}{1}.json", name, index++));
        }
        return nextPath;

    }
}
