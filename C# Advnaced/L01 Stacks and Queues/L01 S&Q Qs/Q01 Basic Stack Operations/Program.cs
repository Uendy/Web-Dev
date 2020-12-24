using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // Reading input and initializing stack:
        var inputTokens = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
        int push = inputTokens[0];
        int pop = inputTokens[1];
        int find = inputTokens[2];

        var stack = new Stack<int>();

        var input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

        // Pushing:
        for (int i = 0; i < push && i < input.Count(); i++)
        {
            stack.Push(input[i]);
        }

        // Popping:
        for (int i = 0; i < pop && stack.Any(); i++)
        {
            stack.Pop();
        }

        // Check for number and print output
        bool contains = stack.Contains(find);
        if (contains)
        {
            Console.WriteLine("true");
        }
        else
        {
            if (stack.Any())
            {
                Console.WriteLine(stack.Min());
            }
            else
            {
                Console.WriteLine(0);
            }
        }

    }
}