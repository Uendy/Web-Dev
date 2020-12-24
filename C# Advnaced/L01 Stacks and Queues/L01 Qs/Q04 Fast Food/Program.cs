using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        int food = int.Parse(Console.ReadLine());
        var orders = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

    }
}