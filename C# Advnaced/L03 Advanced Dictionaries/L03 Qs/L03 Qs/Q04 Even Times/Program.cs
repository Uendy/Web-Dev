using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // Reading inputCounts:
        var inputCounts = int.Parse(Console.ReadLine());

        // Initialize and fill data structure:
        var list = new List<int>();
        for (int i = 0; i < inputCounts; i++)
        {
            list.Add(int.Parse(Console.ReadLine()));
        }

        // Sort and find the entry with odd counts:
        var evenCount = list.GroupBy(x => x).Select(c => new { Key = c.Key, total = c.Count() % 2 == 0 }).First();
        Console.WriteLine(evenCount.Key);
    }
}