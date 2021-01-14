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

        var playerRow = 0;
        var playerCol = 0;

        // Initialize and fill matrix:
        var matrix = new char[rows, cols];
        for (int row = 0; row < rows; row++)
        {
            var currentRow = Console.ReadLine().ToCharArray().ToArray();
            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = currentRow[col];

                bool playerFound = matrix[row, col] == 'P';
                if (playerFound)
                {
                    playerRow = row;
                    playerCol = col;
                }
            }
        }

        // Read commands:
        var commands = Console.ReadLine().ToCharArray().ToList();
        while (true)
        {
            var newRow = playerRow;
            var newCol = playerCol;

            // get move:
            var move = commands[0];
            switch (move)
            {
                case 'U':
                    newRow--;
                    break;

                case 'R':
                    newCol++;
                    break;

                case 'D':
                    newRow++;
                    break;

                case 'L':
                    newCol--;
                    break;
                default:
                    break;
            }

            // move player to new position:
            matrix[playerRow, playerCol] = '.';

            // multiply bunnies: (this is tough as I dont want to multiply then, as I cycle I find a bunny that I just added and multiply it again, or from the first multiplication will recouse and fill the whole matrix)
            // What if I make a list of all B's, then cycle each one and find their neighbours, check each neighbour if legit, then convert.
            var bunnies = new List<int>();
            // cycle through the whole matrix and find all bunnies or just the ones, who dont have all bunny true neighbours, to not cycle so much:
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    bool isBunny = matrix[row, col] == 'B';
                    if (isBunny)
                    {
                        bunnies.Add(row);
                        bunnies.Add(col);
                    }
                }
            }

            // Cycle and find all valid neighbouring bunnies:
            var newBunnies = new List<int>();
            for (int i = 0; i < bunnies.Count(); i += 2)
            {
                var bunnyRow = bunnies[i];
                var bunnyCol = bunnies[i + 1];

                newBunnies = FindNeighbours(bunnyRow, bunnyCol, newBunnies, rows, cols);
            }

            // Cycle through newBunnies and update matrix:
            for (int i = 0; i < newBunnies.Count(); i += 2)
            {
                var bunnyRow = newBunnies[i];
                var bunnyCol = newBunnies[i + 1];

                matrix[bunnyRow, bunnyCol] = 'B';
            }

            // See if valid or player is outside:
            bool playerLeft = newRow < 0
                || newRow >= rows
                || newCol < 0
                || newCol >= cols;
            if (playerLeft)// Print and end program
            {
                // Print matrix and output and end:
                PrintMatrix(matrix, rows, cols);
                Console.WriteLine($"won: {playerRow} {playerCol}");
                return;
            }

            // If player hasn't left, check bunnies:
            playerRow = newRow;
            playerCol = newCol;

            // Check if he stepped on a bunny:
            bool steppedOnBunny = matrix[playerRow, playerCol] == 'B';
            if (steppedOnBunny)
            {
                // Print matrix and output: 
                PrintMatrix(matrix, rows, cols);
                Console.WriteLine($"dead: {playerRow} {playerCol}");
                return;
            }

            // Continue to next command:
            commands.RemoveAt(0);
        }
    }

    public static List<int> FindNeighbours(int bunnyRow, int bunnyCol, List<int> possibleBunnies, int rows, int cols)
    {
        // Up:
        var up = bunnyRow - 1;
        if (ValidIndex(up, bunnyCol, rows, cols))
        {
            possibleBunnies.Add(up);
            possibleBunnies.Add(bunnyCol);
        }

        // Right:
        var right = bunnyCol + 1;
        if (ValidIndex(bunnyRow, right, rows, cols))
        {
            possibleBunnies.Add(bunnyRow);
            possibleBunnies.Add(right);
        }

        // Down:
        var down = bunnyRow + 1;
        if (ValidIndex(down, bunnyCol, rows, cols))
        {
            possibleBunnies.Add(down);
            possibleBunnies.Add(bunnyCol);
        }

        // Left:
        var left = bunnyCol - 1;
        if (ValidIndex(bunnyRow, left, rows, cols))
        {
            possibleBunnies.Add(bunnyRow);
            possibleBunnies.Add(left);
        }

        return possibleBunnies;
    }

    public static bool ValidIndex(int x, int y, int rows, int cols)
    {
        bool isValid = x >= 0 && x < rows
            && y >= 0 && y < cols;

        return isValid;
    }

    public static void PrintMatrix(char[,] matrix, int rows, int cols)
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Console.Write($"{matrix[row, col]}");
            }
            Console.WriteLine();
        }
    }
}