using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // Reading input parameters of matrix:
        var parameters = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        var rows = parameters[0];
        var cols = parameters[1];

        // Initialize and read matrix:
        var matrix = new int[rows, cols];
        for (int row = 0; row < rows; row++)
        {
            var currentRow = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = currentRow[col];
            }
        }

        // find largest 3x3 sum:
        var maxSum = 0;
        var rowIndex = 0;
        var colIndex = 0;

        for (int row = 0; row < rows - 2; row++)
        {
            for (int col = 0; col < cols - 2; col++)
            {
                var currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                    + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                    + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                bool newHighestSum = currentSum > maxSum;
                if (newHighestSum)
                {
                    maxSum = currentSum;
                    rowIndex = row;
                    colIndex = col;
                }
            }
        }

        // Print out sum and the 3x3 matrix:
        Console.WriteLine($"Sum = {maxSum}");
        for (int row = rowIndex; row <= rowIndex + 2; row++)
        {
            for (int col = colIndex; col <= colIndex + 2; col++)
            {
                Console.Write($"{matrix[row, col]} ");
            }
            Console.WriteLine();
        }
    }
}