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

        // Printing count and sum:
        Console.WriteLine(input.Count());
        Console.WriteLine(input.Sum());
    }
}