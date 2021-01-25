using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
public class Program
{
    public static void Main()
    {
        var lines = new List<string>();
        var reader = new StreamReader(@".\text.txt");
        using (reader)
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();

                if (line == null)
                {
                    break;
                }
                
                lines.Add(line);
            }
        }

        var output = new List<string>();
        for (int i = 0; i < lines.Count(); i++)
        {
            bool isEven = i % 2 == 0;
            if (isEven)
            {
                var currentLine = lines[i];
                //{"-", ",", ".", "!", "?"}
                currentLine = currentLine
                    .Replace('-', '@')
                    .Replace(',', '@')
                    .Replace('.', '@')
                    .Replace('!', '@')
                    .Replace('?', '@');

                currentLine = string.Join(" ",currentLine.Split(' ')
                    .Reverse()
                    .ToArray());
                
                output.Add(currentLine);
            }
        }

        foreach (var line in output)
        {
            Console.WriteLine(line);
        }
    }
}