using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // Reading input:
        int numberOfInputs = int.Parse(Console.ReadLine());

        var stack = new Stack<int>();

        for (int i = 0; i < numberOfInputs; i++)
        {
            var inputTokens = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int command = inputTokens[0];

            // Depending on command manipulate stack:
            switch (command)
            {
                case 1:
                    int add = inputTokens[1];
                    stack.Push(add);
                    break;

                case 2:
                    if (stack.Any())
                    {
                        stack.Pop();
                    }
                    break;

                case 3:
                    if (stack.Any())
                    {
                        Console.WriteLine(stack.Max());
                    }
                    break;

                case 4:
                    if (stack.Any())
                    {
                        Console.WriteLine(stack.Min());
                    }
                    break;
                default:
                    break;
            }
        }

        // Print remaining stack:
        bool empty = !stack.Any();
        if (empty)
        {
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine(string.Join(", ", stack));
        }
    }
}