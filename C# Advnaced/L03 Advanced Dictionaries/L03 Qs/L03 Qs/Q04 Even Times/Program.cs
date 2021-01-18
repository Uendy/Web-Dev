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
        var dict = new Dictionary<int, int>();
        for (int i = 0; i < inputCounts; i++)
        {
            var number = int.Parse(Console.ReadLine());
            bool newNum = !dict.ContainsKey(number);
            if(newNum)
            {
                dict[number] = 0;
            }
            dict[number]++;
        }

        // Sort and find the entry with odd counts, then print:
        foreach (var num in dict)
        {
            bool evenCount = num.Value % 2 == 0;
            if (evenCount)
            {
                Console.WriteLine(num.Key);
                return;
            }
        }
    }
}