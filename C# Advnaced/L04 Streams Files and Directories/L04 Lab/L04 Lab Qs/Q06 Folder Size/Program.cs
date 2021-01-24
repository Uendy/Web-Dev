using System.IO;
public class Program
{
    public static void Main()
    {
        var folder = new DirectoryInfo(@"..\..\Test Folder");
        var files = folder.GetFiles();

        var totalLength = 0m;
        foreach (var file in files)
        {
            totalLength += file.Length;
        }

        var megaBytes = totalLength / 1024 / 1024;
        var output = $"{megaBytes:f4} MB";

        File.WriteAllText("output.txt", output);
    }
}