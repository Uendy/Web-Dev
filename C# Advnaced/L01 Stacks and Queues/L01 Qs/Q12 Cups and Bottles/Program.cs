using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // Reading input:
        var bottles = new Queue<int>(Console.ReadLine().Split(' ').Select(int.Parse));
        var cups = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse));
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
                // Find wasted water and add it to total
                int wasted = currentCup - currentBottle;
                wastedWater += wasted;

                // Remove both
                cups.Pop();
                bottles.Dequeue();
            }
            else // cup isnt big enough, 
            {
                currentBottle -= currentCup;
                cups.Pop();
            }
        }

        // Depending on empty bottles or empty cups print output:
        if (bottles.Any())
        {
            Console.WriteLine($"Cups: {string.Join(" ", bottles)}");
        }
        else // Print remaining cups
        {
            Console.WriteLine($"Bottles: {string.Join(" ", cups)}");
        }
        Console.WriteLine($"Wasted litters of water: {wastedWater}");
    }
}