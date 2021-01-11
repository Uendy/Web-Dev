using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // Reading input parameters:
        var size = int.Parse(Console.ReadLine());

        // Intialize and fill matrix:
        var matrix = new int[size][];
        for (int row = 0; row < size; row++)
        {
            matrix[row] = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        }

        // Read bomb coordinates:
        var bombsInput = Console.ReadLine().Split(new string[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        // Find all bombs and explode them:
        for (int bomb = 0; bomb < bombsInput.Count() / 2; bomb+=2)
        {
            int bombRow = bombsInput[bomb];
            int bombCol = bombsInput[bomb + 1];

            matrix = Detonate(matrix, bombRow, bombCol, size);
        }

        // Find number of alive cells and their sum:
        var aliveCells = new List<int>();
        foreach (var row in matrix)
        {
            foreach (var cell in row)
            {
                bool alive = cell > 0;
                if (alive)
                {
                    aliveCells.Add(cell);
                }
            }
        }
        Console.WriteLine($"Alive cells: {aliveCells.Count()}");
        Console.WriteLine($"Sum: {aliveCells.Sum()}");

        // Print the matrix:
        for (int row = 0; row < size; row++)
        {
            Console.WriteLine(string.Join(" ", matrix[row]));
        }
    }

    public static int[][] Detonate(int[][] matrix, int bombRow, int bombCol, int size)
    {
        bool validIndex = CheckIndex(bombRow, bombCol, size);
        if (validIndex)
        {
            int bombDamage = matrix[bombRow][bombCol];

            // Cyle the squares around the bomb and if possible reduce them
            for (int row = bombRow - 1; row <= bombRow + 1; row++)
            {
                for (int col = bombCol - 1; col <= bombCol + 1; col++)
                {
                    // bomb reduces itself to 0
                    bool isBomb = row == bombRow && col == bombCol;
                    if (isBomb)
                    {
                        matrix[bombRow][bombCol] = 0;
                        continue;
                    }

                    if (CheckIndex(row, col, size))
                    {
                        // if its already dead (> 0), dont do anything, if alive, reduce by bomb damage
                        bool isAlive = matrix[row][col] >= 0;
                        if (isAlive)
                        {
                            matrix[row][col] -= bombDamage;
                        }
                    }
                }
            }
        }

        return matrix;
    }
    public static bool CheckIndex(int row, int col, int size)
    {
        bool rowValid = row >= 0 && row < size;
        bool colValid = col >= 0 && col < size;

        return rowValid && colValid;
    }
}