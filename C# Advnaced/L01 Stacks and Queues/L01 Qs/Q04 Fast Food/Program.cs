using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // Read input and initialize:
        int food = int.Parse(Console.ReadLine());
        var orders = new Queue<int>(Console.ReadLine().Split(' ').Select(int.Parse).ToList());

        // Find biggest order
        int biggestOrder = orders.Max();
        Console.WriteLine(biggestOrder);

        // Accept the orders (if possible)
        foreach (var order in orders.ToList())
        {
            bool enoughFood = food >= order;
            if (enoughFood)
            {
                food -= order;
                orders.Dequeue();
            }
            else // even if you can fill more orders, apart from the one you can't you should stop
            {
                break;
            }
        }

        // Depending on order print:
        bool complete = !orders.Any();
        if (complete)
        {
            Console.WriteLine("Orders complete");
        }
        else
        {
            Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
        }
    }
}