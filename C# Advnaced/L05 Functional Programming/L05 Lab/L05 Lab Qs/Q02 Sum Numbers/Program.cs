using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // Intialize function:
        Func<string, int> parseFunc = int.Parse; 

        // Reading input:
        var input = Console.ReadLine()
            .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(parseFunc)
            .ToList();

        // Printing count and sum:
        Console.WriteLine(input.Count());
        Console.WriteLine(input.Sum());
    }
}