using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        var inputs = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();

        Action <string> print = x => Console.WriteLine(x);

        inputs.ForEach(x => print(x));
    }
}