using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        var list = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

        Func<List<int>, int> customMin = FindMin;

        var result = customMin(list);
        Console.WriteLine(result);
    }
    public static int FindMin(List<int> list)
    {
        int min = int.MaxValue;
        foreach (var item in list)
        {
            if (item < min)
            {
                min = item;
            }
        }

        return min;
    }
}