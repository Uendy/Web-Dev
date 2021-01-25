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

            currentLine.PunctuationMarks = line.Where(char.IsPunctuation).Count();
            
            File.AppendAllText("output.txt", $"Line {currentLine.Number}: {line} ({currentLine.Letters})({currentLine.PunctuationMarks})\n");

            lineNum++;
        }
    }
}