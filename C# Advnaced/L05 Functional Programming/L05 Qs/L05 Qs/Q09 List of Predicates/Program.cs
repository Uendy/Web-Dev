using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        var end = int.Parse(Console.ReadLine());
        var numerators = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Distinct().ToList();

        // Check each number in range (1 to end), with each denominator
        var numbersThatPass = new List<int>();
        for (int currentNum = 1; currentNum <= end; currentNum++)
        {
            bool passes = true;

            // Change Func(denominator) each time
            foreach (var numerator in numerators)
            {
                Func<int, bool> Divider = DivideBy(numerator);
                bool currentCheck = Divider(currentNum);
                if (currentCheck == false)
                {
                    passes = false;
                    break;
                }
            }

            if (passes)
            {
                numbersThatPass.Add(currentNum);
            }
        }

        Console.WriteLine(string.Join(" ", numbersThatPass));
    }
    public static Func<int, bool> DivideBy(int numerator)
    {
        return x => x % numerator == 0;
    }
}