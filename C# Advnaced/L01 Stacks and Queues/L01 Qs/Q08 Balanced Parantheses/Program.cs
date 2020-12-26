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
        var waveyStack = new Stack<int>(); // {

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
                    CheckBalance(input, curveStack, i);
                    CheckAndExecute(curveStack);
                    break;

                case '[':
                    squareStack.Push(i);
                    break;

                case ']':
                    CheckBalance(input, squareStack, i);
                    CheckAndExecute(squareStack);
                    break;

                case '{':
                    waveyStack.Push(i);
                    break;

                case '}':
                    CheckBalance(input, waveyStack, i);
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

    public static void CheckBalance(string input, Stack<int> stack, int i) // if there is an odd number between them it means it isnt balanced
    {
        int distance = i - stack.Peek() + 1;
        string substring = input.Substring(stack.Peek(), distance);
        bool oddLength = substring.Count() % 2 != 0;
        if (oddLength)
        {
            Console.WriteLine("NO");
            Environment.Exit(0);
        }
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