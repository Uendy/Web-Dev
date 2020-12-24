using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // Reading input: 
        var inputTokens = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
        int enqueue = inputTokens[0];
        int dequeue = inputTokens[1];
        int find = inputTokens[2];

        var input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

        // Initialize and Enqueue, Dequeue Queue
        var queue = new Queue<int>();
        for (int i = 0; i < enqueue && i < input.Count(); i++)
        {
            queue.Enqueue(input[i]);
        }

        for (int i = 0; i < dequeue && queue.Any(); i++)
        {
            queue.Dequeue();
        }

        // Find and print depending
        bool contains = queue.Contains(find);
        if (contains)
        {
            Console.WriteLine("true");
        }
        else
        {
            bool emptyQueue = !queue.Any();
            if (emptyQueue)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}