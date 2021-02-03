using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        var numbers = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

        Func<List<int>, List<int>> Sorter = SortList(numbers);
        numbers = Sorter(numbers);

        Console.WriteLine(string.Join(" ", numbers));
    }
    public static Func<List<int>, List<int>> SortList(List<int> numbers)
    {
        return x => numbers.OrderBy(n => n % 2 != 0).ThenBy(n => n % 2 == 0).ToList();
    }
}