using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // Reading input:
        var input = Console.ReadLine().ToCharArray();

        // Initialize dict: key = char, value = count:
        var symbols = new SortedDictionary<char, int>();

        // Cycle input and update dict:
        for (int i = 0; i < input.Count(); i++)
        {
            var currentChar = input[i];
            bool newSymbol = !symbols.ContainsKey(currentChar);
            if (newSymbol)
            {
                symbols[currentChar] = 0;
            }

            symbols[currentChar]++;
        }

        // Print each char and its corresponding counts:
        foreach (var symbol in symbols)
        {
            Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
        }
    }
}