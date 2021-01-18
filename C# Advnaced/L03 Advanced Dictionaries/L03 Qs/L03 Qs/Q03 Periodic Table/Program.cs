using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // Reading parameters:
        var inputCount = int.Parse(Console.ReadLine());

        // Intialize Hashset and fill:
        var table = new SortedSet<string>();
        for (int i = 0; i < inputCount; i++)
        {
            var elements = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            foreach (var element in elements)
            {
                table.Add(element);
            }
        }

        // Print all unique elements:
        Console.WriteLine(string.Join(" ", table));
    }
}