using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        var targetCharactersSum = int.Parse(Console.ReadLine());
        var names = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();

        Func<string, int, bool> isValidWord = (str, num) => str.ToCharArray()
            .Select(ch => (int)ch).Sum() >= num;

        Func<List<string>, int, Func<string, int, bool>, string> firstValidName = (list, num, func) => list
            .FirstOrDefault(str => func(str, num));

        var result = firstValidName(names, targetCharactersSum, isValidWord);
        Console.WriteLine(result);
    }
}