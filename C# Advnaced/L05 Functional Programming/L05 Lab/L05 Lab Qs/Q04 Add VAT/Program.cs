using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        Func<string, double> doubleParser = x => double.Parse(x);
        Func<double, double> addVat = x => x * 1.2;

        var input = Console.ReadLine()
            .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(doubleParser)
            .Select(addVat)
            .ToList();

        input.Select(addVat);

        foreach (var price in input)
        {
            Console.WriteLine($"{price:f2}");
        }
    }
}