using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // Reading size of matrix:
        var parameters = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        var rows = parameters[0];
        var cols = parameters[1];

        // Initializing and filling the matrix:
        var playerRow = 0;
        var playerCol = 0;

        var matrix = new int[rows][];
        for (int row = 0; row < rows; row++)
        {
            var rowElements = Console.ReadLine().ToCharArray().ToArray();

            matrix[row] = new int[cols];
            for (int col = 0; col < cols; col++)
            {
                matrix[row][col] = rowElements[col];

                // Finding player coordinates
                bool playerFound = matrix[row][col] == 'P';
                if (playerFound)
                {
                    playerRow = row;
                    playerCol = col;
                }
            }
        }

        // Reading and executing commands:
        var commands = Console.ReadLine().ToCharArray().ToArray();
        while (true)
        {
            matrix[playerRow][playerCol] = '.';

            var currentCommand = commands[0];

            switch (currentCommand)
            {
                case 'U': // Up
                    playerRow--;
                    break;

                case 'R': // Right
                    playerCol++;
                    break;

                case 'D': // Down
                    playerRow++;
                    break;

                case 'L': // Left
                    playerCol--;
                    break;
                default:
                    break;
            }

            // Find all current bunnies:
            var currentBunnies = new List<int[]>();
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    bool isBunny = matrix[row][col] == 'B';
                    if (isBunny)
                    {
                        currentBunnies.Add(new int[2]);
                        currentBunnies[currentBunnies.Count() - 1][0] = row;
                        currentBunnies[currentBunnies.Count() - 1][1] = col;
                    }
                }
            }

            // Cycle and find all valid neighbouring bunnies:
            var newBunnies = new List<int[]>();
            foreach (var bunny in currentBunnies)
            {
                newBunnies = FindNeighbours(bunny, rows, cols);
            }
        }
    }

    public static List<int[]> FindNeighbours(int[] bunny, int rows, int cols)
    {
        var newBunnies = new List<int[]>();

        var row = bunny[0];
        var col = bunny[1];

        // Up:
        var up = row - 1;
        if (CheckIndex(up, col, rows, cols))
        {
            newBunnies.Add(new int[2]);
            newBunnies[newBunnies.Count() - 1][0] = up;
            newBunnies[newBunnies.Count() - 1][1] = col;
        }

        // Right:
        var right = col + 1;
        if (CheckIndex(row, right, row, cols))
        {
            newBunnies.Add(new int[2]);
            newBunnies[newBunnies.Count() - 1][0] = row;
            newBunnies[newBunnies.Count() - 1][1] = right;
        }

        // Down:
        var down = row + 1;
        if (CheckIndex(down, col, rows, cols))
        {
            newBunnies.Add(new int[2]);
            newBunnies[newBunnies.Count() - 1][0] = down;
            newBunnies[newBunnies.Count() - 1][1] = col;
        }

        // Left:
        var left = col - 1;
        if (CheckIndex(row, left, rows, cols))
        {
            newBunnies.Add(new int[2]);
            newBunnies[newBunnies.Count() - 1][0] = row;
            newBunnies[newBunnies.Count() - 1][1] = left;
        }

        return newBunnies;
    }

    public static bool CheckIndex(int row, int col, int rows, int cols)
    {
        bool isValid = row >= 0 && row < rows
            && col >= 0 && col < cols;

        return isValid;
    }
}