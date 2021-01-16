using System;
using System.Collections.Generic;
public class Program
{
    public static void Main()
    {
        // Read inputCount:
        var inputCount = int.Parse(Console.ReadLine());

        // Initialize hashset:
        var hashset = new HashSet<string>();

        // Fill with input:
        for (int i = 0; i < inputCount; i++)
        {
            hashset.Add(Console.ReadLine());
        }

        // Print the hashset contents:
        foreach (var name in hashset)
        {
            Console.WriteLine(name);
        }
    }
}