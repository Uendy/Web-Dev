using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        var list = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

        string command;
        while ((command = Console.ReadLine()) != "end")
        {
            if (command == "print")
            {
                Action<List<int>> Printer = Print();
                Printer(list);
            }
            else
            {
                Func<int, int> MyFunc = ManipulateList(command);
                list = list.Select(x => MyFunc(x)).ToList();
            }
        }
    }
    public static Action<List<int>> Print()
    {
        return x => Console.WriteLine(string.Join(" ", x));
    }

    public static Func<int, int> ManipulateList(string command)
    {
        switch (command)
        {
            case "add":
                return x => x + 1;

            case "subtract":
                return x => x - 1;

            case "multiply":
                return x => x * 2;

            default:
                return x => x;
        }
    }
}