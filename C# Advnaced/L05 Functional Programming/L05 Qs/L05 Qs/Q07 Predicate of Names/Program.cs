using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        var length = int.Parse(Console.ReadLine());
        Func<string, bool> checkLength = CheckLength(length);

        var names = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
        names = names.Where(x => checkLength(x)).ToList();

        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
    }
    public static Func<string, bool> CheckLength(int length)
    {
        return x => x.Length <= length;
    }
}