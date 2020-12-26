using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // Reading input:
        string input = Console.ReadLine();
        var curveStack = new Stack<int>(); // (
        var squareStack = new Stack<int>(); //[
        var waveyStack = new Stack<int>();

        // check for palendrome, otherwise the sequence is unbalanced:
        bool isPalendrome = CheckPalendrome(input);
        if (!isPalendrome)
        {
            Console.WriteLine("NO");
            return;
        }

        // Cycle through input chars and depending on currenct char, update the corresponding stack:
        var inputAsArray = input.ToCharArray();
        for (int i = 0; i < inputAsArray.Count(); i++)
        {
            char current = inputAsArray[i];

            switch (current)
            {
                case '(':
                    curveStack.Push(i);
                    break;

                case ')':
                    CheckAndExecute(curveStack);
                    break;

                case '[':
                    squareStack.Push(i);
                    break;

                case ']':
                    CheckAndExecute(squareStack);
                    break;

                case '{':
                    waveyStack.Push(i);
                    break;

                case '}':
                    CheckAndExecute(waveyStack);
                    break;
            }
        }

        bool finalCheck = !curveStack.Any() || !squareStack.Any() || waveyStack.Any();
        if (finalCheck)
        {
            Console.WriteLine("YES");
        }
        else
        {
            Console.WriteLine("NO");
        }
    }

    public static bool CheckPalendrome(string input)
    {
        return input.SequenceEqual(input.Reverse());
    }

    public static void CheckAndExecute(Stack<int> stack) // Check for the element in its given stack and if there remove its partner or print fail
    {
        bool contains = stack.Any();
        if (contains)
        {
            stack.Pop();
        }
        else // shut it down
        {
            Console.WriteLine("NO");
            Environment.Exit(0); 
        }
    }
}