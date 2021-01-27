using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
public class Program
{
    public static void Main()
    {
        var files = Directory.GetFiles(@"../../.");

        var filesAndExtension = new Dictionary<string, Dictionary<string, double>>();

        // trim files:
        foreach (var file in files)
        {
            // Trying to remove the path prefix: ..//..//.\
            var fileInfo = file.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries).Last();

            var fileParts = fileInfo.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var fileName = fileParts[0];
            var fileExtension = fileParts[1];

            bool newExtension = !filesAndExtension.ContainsKey(fileExtension);
            if (newExtension)
            {
                filesAndExtension[fileExtension] = new Dictionary<string, double>();
            }

            var size = new FileInfo(file).Length / (double)1024 / 1024;
            filesAndExtension[fileExtension][fileName] = size;
        }

        // Ordering the values:
        filesAndExtension
            .OrderByDescending(x => x.Value.Count())
            .ThenBy(x => x.Key)
            .ToDictionary(x => x.Key, y => y.Value);

        var outputLines = new List<string>();

        foreach (var extension in filesAndExtension)
        {
            outputLines.Add($".{extension.Key}");
            foreach (var file in filesAndExtension[extension.Key].OrderByDescending(x => x.Value))
            {
                outputLines.Add($"--{file.Key}.{extension.Key} - {file.Value:f4}kb");
            }
        }

        // Had to google this, as desktop had writting restrictions
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string filepath = path + "\\output.txt";
        File.WriteAllLines(filepath, outputLines);
    }
}