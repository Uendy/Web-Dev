using System;
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
            var currentRow = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
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

            // See if valid or player is outside:
            bool playerLeft = newRow < 0 
                || newRow >= rows
                || newCol < 0 
                || newCol >= cols;
            if (playerLeft)// Print and end program
            {
                // Print matrix and output and end:
                PrintMatrix(matrix);
                Console.WriteLine($"won: {playerRow} {playerCol}");
                return;
            }
            else
            {
                // move player to new position:
                matrix[playerRow, playerCol] = '.';
                playerRow = newRow;
                playerCol = newCol;

                // multiply bunnies: (this is tough as I dont want to multiply then, as I cycle I find a bunny that I just added and multiply it again, or from the first multiplication will recouse and fill the whole matrix)

                // Check if he stepped on a bunny:
                bool steppedOnBunny = matrix[playerRow, playerCol] == 'B';
                if (steppedOnBunny)
                {
                    // Print matrix and output: 
                    PrintMatrix(matrix);
                    Console.WriteLine($"dead: {playerRow} {playerCol}");
                    return;
                }
            }

            // Continue to next command:
            commands.RemoveAt(0);
        }
    }

    public static void PrintMatrix(char[,] matrix)
    {
        foreach (var row in matrix)
        {
            Console.WriteLine(string.Join(" ", row));
        }
    }
}