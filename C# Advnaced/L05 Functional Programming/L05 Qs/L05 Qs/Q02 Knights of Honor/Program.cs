using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        var inputs = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();

        Action<string> honorPrinter = x => Console.WriteLine($"Sir {x}");

        inputs.ForEach(x => honorPrinter(x));
    }
}