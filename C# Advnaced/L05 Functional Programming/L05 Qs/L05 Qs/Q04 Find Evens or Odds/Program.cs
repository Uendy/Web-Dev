using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        var list = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        var start = list[0];
        var end = list[1];

        // Getting values between first and last:
        for (int i = start; i < end; i++)
        {
            list.Insert(list.Count() - 1, i);
        }

        string oddOrEven = Console.ReadLine().ToLower();

        Func<int, bool> FilterFunc = FilterList(oddOrEven);

        list = list.Where(x => FilterFunc(x)).ToList();
        Console.WriteLine(string.Join(" ", list));
    }

    public static Func<int, bool> FilterList(string oddOrEven)
    {
        switch (oddOrEven)
        {
            case "odd":
                return x => x % 2 != 0;

            case "even":
                return x => x % 2 == 0;
                
            default:
                return x => x == x;
        }
    }
}