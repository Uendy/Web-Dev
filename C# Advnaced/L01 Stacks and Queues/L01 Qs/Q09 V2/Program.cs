using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    public static void Main()
    {
        // Reading input:
        int numberOfInput = int.Parse(Console.ReadLine());
        string text = string.Empty;
        var stack = new Stack<string>();

        // Read command and execute:
        for (int i = 0; i < numberOfInput; i++)
        {
            var commandLine = Console.ReadLine().Split(' ').ToArray();
            string command = commandLine[0];

            switch (command)
            {
                case "1":
                    string add = commandLine[1];
                    text += add;
                    stack.Push(text);
                    break;

                case "2":
                    int removeCount = int.Parse(commandLine[1]);
                    text = text.Substring(0, text.Length - removeCount);
                    stack.Push(text);
                    break;

                case "3":
                    int index = int.Parse(commandLine[1]);
                    Console.WriteLine(text[index - 1]);
                    break;

                case "4": // takes last stack element if any, if not it will return an empty string
                    if(stack.Count > 1)
                    {
                        stack.Pop();
                        text = stack.Peek();
                    }
                    else
                    {
                        text = string.Empty;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}