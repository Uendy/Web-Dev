using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        var list = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

        // To Revese the list, without using .Reverse()
        Func<List<int>, List<int>> Reverser = ReverseList(list);
        list = Reverser(list);

        // To exclude divisable numbers
        var denominator = int.Parse(Console.ReadLine());
        Func<int, bool> Excludor = ExcludeDivisableElements(denominator);
        list = list.Where(x => Excludor(x) != true).ToList();

        Console.WriteLine(string.Join(" ", list));
    }
    public static Func<List<int>, List<int>> ReverseList(List<int> list)
    {
        var newList = new List<int>();
        for (int i = list.Count() - 1; i >= 0; i--)
        {
            newList.Add(list[i]);
        }

        return x => newList;
    }
    public static Func<int, bool> ExcludeDivisableElements(int denominator)
    {
        return x => x % denominator == 0;
    }
}