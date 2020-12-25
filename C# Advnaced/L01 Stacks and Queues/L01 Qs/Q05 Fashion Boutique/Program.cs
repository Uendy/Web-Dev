using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // Reading input:
        var clothes = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse).ToList());
        var rackSize = int.Parse(Console.ReadLine());

        var currentSum = 0;
        var racksUsed = 1;

        // Cycle and sum, while keeping track of racks used:
        while (clothes.Any())
        {
            currentSum += clothes.Peek();

            if (currentSum <= rackSize)
            {
                clothes.Pop();
            }
            else
            {
                currentSum = 0;
                racksUsed++;
            }
        }

        // Print output:
        Console.WriteLine(racksUsed);
    }
}