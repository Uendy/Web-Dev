using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        Func<string, bool> capitalizationChecker = n => n[0] == n.ToUpper()[0];

        var input = Console.ReadLine()
            .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
            .Where(capitalizationChecker)
            .ToList();

        foreach (var word in input)
        {
            Console.WriteLine(word);
        }
    }
}