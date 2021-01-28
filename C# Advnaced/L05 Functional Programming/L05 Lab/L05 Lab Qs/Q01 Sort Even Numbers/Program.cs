using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // Reading input:
        var input = Console.ReadLine()
            .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        // Execute lambda expression:
        var evenNums = input
            .Where(x => x % 2 == 0)
            .OrderBy(x => x)
            .ToList();

        // Printing output:
        Console.WriteLine(string.Join(", ", evenNums));
    }
}