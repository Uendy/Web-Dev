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
                    // 1 someString - appends someString to the end of the text
                    var someString = currentTask[1].ToCharArray();
                    list = AddSomeString(list, someString);
                    break;

                case "2":
                    // 2 count - erases the last count elements from the text
                    int count = int.Parse(currentTask[1]);
                    list = ListEraseCount(list, count);
                    break;

                case "3":
                    // 3 index - returns the element at position index from the text
                    int index = int.Parse(currentTask[1]);
                    Console.WriteLine(list[index - 1]);
                    break;

                case "4":
                    // 4 - undoes the last not undone command of type 1 / 2 and returns the text to the state before that operation
                    // This will be tricky, can I add 1/2 commands to a queue and return?
                    break;
            }
            tasks.Dequeue();
        }
    }

    public static List<string> AddSomeString(List<string> list, char[] someString)
    {
        foreach (var item in someString)
        {
            list.Add(item.ToString());
        }
        return list;
    }

    public static List<string> ListEraseCount(List<string> list, int count)
    {
        bool enoughElements = list.Count() > count;
        if (enoughElements)
        {
            int indexToRemove = list.Count() - 3;
            list.RemoveRange(indexToRemove, count);
        }
        else
        {
            list.Clear();
        }
        return list;
    }
}