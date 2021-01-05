using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // Reading input parameters of matrix:
        var size = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        var rows = size[0];
        var cols = size[1];

        // Initialize and fill matrix:
        var matrix = new int[rows][];
        for (int row = 0; row < rows; row++)
        {
            matrix[row] = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        }

        // Find biggest 3x3 sum:
        var maxSum = 0;
        var rowIndex = 0;
        var colIndex = 0;

        for (int row = 0; row < rows - 2; row++)
        {
            for (int col = 0; col < cols - 2; col++)
            {
                int sum = matrix[row][col] + matrix[row][col + 1] + matrix[row][col + 2]
                    + matrix[row + 1][col] + matrix[row + 1][col + 1] + matrix[row + 1][col + 2]
                    + matrix[row + 2][col] + matrix[row + 2][col + 1] + matrix[row + 2][col + 2];

                if (sum > maxSum)
                {
                    maxSum = sum;
                    rowIndex = row;
                    colIndex = col;
                }
            }
        }

        // Printing sum and 3x3 matrix:
        Console.WriteLine($"Sum = {maxSum}");
        for (int row = rowIndex; row <= rowIndex + 2; row++)
        {
            for (int col = colIndex; col <= colIndex + 2; col++)
            {
                Console.Write($"{matrix[row][col]} ");
            }
            Console.WriteLine();
        }
    }
}