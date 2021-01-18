using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // Reading parameters: 
        var parameters = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        
        // Initiliaze and fill first set:
        var firstSet = new HashSet<int>();
        for (int i = 0; i < parameters[0]; i++)
        {
            firstSet.Add(int.Parse(Console.ReadLine()));
        }

        // Initialize and fill second set:
        var secondSet = new HashSet<int>();
        for (int i = 0; i < parameters[1]; i++)
        {
            secondSet.Add(int.Parse(Console.ReadLine()));
        }

        // Find numbers that are in both sets:
        var numsInBothSets = new List<int>();

        foreach (var num in firstSet)
        {
            bool inBothSets = secondSet.Contains(num);
            if (inBothSets)
            {
                numsInBothSets.Add(num);
            }
        }

        // Printing all those numbers:
        Console.WriteLine(string.Join(" ", numsInBothSets));
    }
}