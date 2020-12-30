using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // Reading input:
        var bottles = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse));
        var cups = new Queue<int>(Console.ReadLine().Split(' ').Select(int.Parse));
        int wastedWater = 0;

        // Begin pouring water:
        while (bottles.Any() && cups.Any())
        {
            int currentBottle = bottles.Peek();
            int currentCup = cups.Peek();

            // Need to get the logic of the question
            bool cupIsEnough = currentCup >= currentBottle;
            if (cupIsEnough)
            {
                //int waterWasted = currentBottle - currentCup;
            }
            else
            { 
            
            }
        }

        // Depending on empty bottles or empty cups print output:
        if (bottles.Any())
        {
            Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
        }
        else // Print remaining cups
        {
            Console.WriteLine($"Cups: {string.Join(" ", cups)}");
        }
        Console.WriteLine($"Wasted litters of water: {wastedWater}");
    }
}