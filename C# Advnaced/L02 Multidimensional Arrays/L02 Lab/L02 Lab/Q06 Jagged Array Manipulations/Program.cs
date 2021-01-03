using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // Reading rows and initializing jarr
        var rows = int.Parse(Console.ReadLine());
        var jarr = new int[rows][];

        // Filling jarr:
        for (int row = 0; row < rows; row++)
        {
            jarr[row] = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        }

        // Read command and modify jarr:
        string input = Console.ReadLine();
        while (input != "END")
        {
            var inputElements = input.Split(' ').ToArray();
            var command = inputElements[0];
            var row = int.Parse(inputElements[1]);
            var col = int.Parse(inputElements[2]);
            var modifier = int.Parse(inputElements[3]);

            // Check if coordinates are legit:
            bool coordinatesExist = row >= 0 && row < rows && col >= 0 && col < jarr[row].Length;
            if (coordinatesExist)
            {
                switch (command)
                {
                    case "Add":
                        jarr[row][col] += modifier;
                        break;

                    case "Subtract":
                        jarr[row][col] -= modifier;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid coordinates");
            }
            input = Console.ReadLine();
        }

        // Print output:
        foreach (var row in jarr)
        {
            Console.WriteLine(string.Join(" ", row));
        }
    }
}