using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // Reading size parameters:
        var parameters = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        var rows = parameters[0];
        var cols = parameters[1];

        // Initialize matrix and read rows and add elements:
        var matrix = new int[rows, cols];
        for (int row = 0; row < rows; row++)
        {
            var currentRow = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = currentRow[col];
            }
        }

        var maxSum = 0;
        var maxRow = 0;
        var maxCol = 0;

        // Begin going 2x2 and find biggest square
        for (int row = 0; row < rows-1; row++)
        {
            var currentMatrix = new int[2, 2];
            for (int col = 0; col < cols-1; col++)
            {
                int currentSum = matrix[row, col]
                    + matrix[row, col + 1]
                    + matrix[row + 1, col]
                    + matrix[row + 1, col + 1];

                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    maxRow = row;
                    maxCol = col;
                }
            }
        }

        Console.WriteLine($"{matrix[maxRow, maxCol]} {matrix[maxRow, maxCol + 1]}");
        Console.WriteLine($"{matrix[maxRow + 1, maxCol]} {matrix[maxRow + 1, maxCol + 1]}");
        Console.WriteLine(maxSum);
    }
}