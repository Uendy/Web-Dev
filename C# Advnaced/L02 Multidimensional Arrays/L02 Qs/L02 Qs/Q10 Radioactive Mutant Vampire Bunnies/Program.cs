using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // Var reading matrix parameters:
        var parameters = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        var rows = parameters[0];
        var cols = parameters[1];

        // Initialize and fill matrix:
        var matrix = new char[rows, cols];
        for (int row = 0; row < rows; row++)
        {
            var currentRow = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = currentRow[col];
            }
        }

        // Read commands:
        var commands = Console.ReadLine().ToCharArray().ToList();
        while (true)
        {
            // get move:
            // See if valid or player is outside:
            // if(outside)
            // { Print and end program}

            // else
            // { move player there, then update all bunnies }
            // See if bunnies get to player 
            // if(they get player)
            // {print dead and end}

            // Continue to next command:
            commands.RemoveAt(0);
        }
    }
}