using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
public class Program
{
    public static void Main()
    {
        var keyWords = File.ReadAllLines("words.txt");
        var lines = File.ReadAllText("text.txt")
            .Split(new string[] { " ", ".", ",", "-", "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.ToLower())
            .ToList();

        var wordCount = new Dictionary<string, int>();
        foreach (var word in lines)
        {
            bool isKeyWord = keyWords.Contains(word);
            if (isKeyWord)
            {
                bool newKeyWord = !wordCount.ContainsKey(word);
                if (newKeyWord)
                {
                    wordCount[word] = 0;
                }

                wordCount[word]++;
            }
        }

        var wordsCountLines = new List<string>();
        foreach (var word in wordCount)
        {
            wordsCountLines.Add($"{word.Key} - {word.Value}");
        }

        var sortedWords = wordCount.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, y => y.Value);
        var sortedWordLines = new List<string>();
        foreach (var word in sortedWords)
        {
            sortedWordLines.Add($"{word.Key} - {word.Value}");
        }

        File.WriteAllLines("actualResult.txt", wordsCountLines);
        File.WriteAllLines("expectedResult.txt", sortedWordLines);
    }
}