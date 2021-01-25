using System.Collections.Generic;
using System.Linq;
using System.IO;
public class Program
{
    public static void Main()
    {
        var lines = File.ReadAllLines("text.txt");
        File.Delete("output.txt");

        int lineNum = 1;
        foreach (var line in lines)
        {
            var currentLine = new Line();

            currentLine.Number = lineNum;

            currentLine.Letters = line.Where(char.IsLetter).Count();

            var punctuationMarks = new List<char> { '-', ',', '.', '!', '?', '\''};
            currentLine.PunctuationMarks = FindPunctuationMarks(line, punctuationMarks);

            
            File.AppendAllText("output.txt", $"Line {currentLine.Number}: {line} ({currentLine.Letters})({currentLine.PunctuationMarks})\n");

            lineNum++;
        }

    }
    public static int FindPunctuationMarks(string line, List<char> punctuationMarks)
    {
        int count = 0;
        foreach (var symbol in line.ToCharArray())
        {
            bool isPunctuationMark = punctuationMarks.Contains(symbol);
            if (isPunctuationMark)
            {
                count++;
            }
        }

        return count;
    }
}