using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // Reading input:
        var array = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToArray();

        // Initialize and fill dictionary:
        var dict = new Dictionary<decimal, int>(); // Key = decimal number, Value = count of occurances
        foreach (var number in array)
        {
            // If not in dict, add it:
            bool newNumber = !dict.ContainsKey(number);
            if (newNumber)
            {
                dict[number] = 0;
            }
            dict[number]++;
        }

        // Print results
        foreach (var num in dict)
        {
            Console.WriteLine($"{num.Key} - {num.Value} times");
        }
    }
}