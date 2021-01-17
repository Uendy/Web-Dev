using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // Initialize HashSet:
        var parking = new HashSet<string>();

        // Reading input and updating parking:
        string input = Console.ReadLine();
        while (input != "END")
        {
            var inputElements = input.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var command = inputElements[0];
            var car = inputElements[1];

            switch (command)
            {
                case "IN":
                    parking.Add(car);
                    break;

                case "OUT":
                    parking.Remove(car);
                    break;
                default:
                    break;
            }

            // Continue reading input:
            input = Console.ReadLine();
        }

        // Print remaining cars if any:
        if (parking.Count() == 0)
        {
            Console.WriteLine("Parking Lot is Empty");
        }
        else
        {
            foreach (var car in parking)
            {
                Console.WriteLine(car);
            }
        }
    }
}