using System;
using System.Collections.Generic;
public class Program
{
    public static void Main()
    {
        // Read inputCount:
        var inputCount = int.Parse(Console.ReadLine());

        // Initialize hashset:
        var names = new HashSet<string>();

        // Fill with input:
        for (int i = 0; i < inputCount; i++)
        {
            names.Add(Console.ReadLine());
        }

        // Print the hashset contents:
        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
    }
}