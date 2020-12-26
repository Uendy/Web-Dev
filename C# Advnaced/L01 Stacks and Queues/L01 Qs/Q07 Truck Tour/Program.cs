using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // Reading and initializing:
        var stations = int.Parse(Console.ReadLine());
        var petrol = new Queue<int>();
        var distance = new Queue<int>();

        for (int i = 0; i < stations; i++)
        {
            var stationData = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            petrol.Enqueue(stationData[0]);
            distance.Enqueue(stationData[1]);
        }

        int currentFuel = 0;
    }
}