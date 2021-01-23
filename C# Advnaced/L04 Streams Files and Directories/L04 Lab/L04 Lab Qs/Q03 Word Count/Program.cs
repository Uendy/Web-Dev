using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
public class Program
{
    public static void Main()
    {
        var text = File.ReadAllText(@"..\..\Input.txt")
            .Split(new string[] { " ", "-", ".", "," }, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.ToLower())
            .ToArray();
        var keywords = File.ReadAllText(@"..\..\words.txt")
            .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.ToLower())
            .ToArray();

        var wordCount = new Dictionary<string, int>();

        foreach (var word in text)
        {
            bool keyWordFound = keywords.Contains(word);
            if (keyWordFound)
            {
                bool newWord = !wordCount.ContainsKey(word);
                if (newWord)
                {
                    wordCount[word] = 0;
                }
                wordCount[word]++;
            }
        }

        foreach (var word in wordCount.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, y => y.Value))
        {
            string output = $"{word.Key} - {word.Value}\r\n";
            File.AppendAllText(@"..\..\Output.txt", output);
        }
        
    }
}