using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // Reading and intializng stack of commands:
        int commands = int.Parse(Console.ReadLine());
        var tasks = new Queue<string>();
        for (int i = 0; i < commands; i++)
        {
            tasks.Enqueue(Console.ReadLine());
        }

        // Begin executing command:
        var list = new List<string>();
        while (tasks.Any())
        {
            var currentTask = tasks.Peek().Split(' ').ToArray();
            var task = currentTask[0];

            switch (task)
            {
                case "1":
                    //
                    break;

                case "2":
                    //
                    break;

                case "3":
                    //
                    break;

                case "4":
                    //
                    break;
            }
        }
    }
}