using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        var list = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

        string oddOrEven = Console.ReadLine().ToLower();

        Func<int, bool> FilterFunc = FilterList(oddOrEven);

        list.Where(x => FilterFunc(x)).ToList();
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
                return null;
        }
    }
}