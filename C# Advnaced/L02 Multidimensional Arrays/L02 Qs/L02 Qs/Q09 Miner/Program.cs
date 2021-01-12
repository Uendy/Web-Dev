using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // Reading input parameters:
        var size = int.Parse(Console.ReadLine());
        var commands = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();

        // Initialize and fill matrix, while keeping track of start point and total coals:
        var currentRow = -1; 
        var currentCol = -1;
        var coalRemaining = 0;

        var matrix = new char[size,size];
        for (int row = 0; row < size; row++)
        {
            var currentRowElements = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
            for (int col = 0; col < size; col++)
            {
                matrix[row,col] = currentRowElements[col];

                bool isCoal = currentRowElements[col] == 'c';
                if (isCoal)
                {
                    coalRemaining++;
                }

                bool isStart = currentRowElements[col] == 's';
                if (isStart)
                {
                    currentRow = row;
                    currentCol = col;
                }
            }
        }

        // Begin executing commands:
        while (commands.Any())
        {
            // Move:

            // if invalid inded, skip command

            // if coal: pick it up and replace with '*'

                // if no more coal print and end program

            // reached end 'e', print and end the program

            commands.RemoveAt(0);
        }

        // If no more commands: print and end program:
    }
}