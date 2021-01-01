using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // Reading matrix parameters:
        var paramaters = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        int rows = paramaters[0];
        int cols = paramaters[1];

        // Initialize matrix:
        var matrix = new int[rows, cols];
        for (int row = 0; row < rows; row++)
        {
            var currentRow = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = currentRow[col];
            }
        }

        // Initializing sum, cycling matrix:
        var sums = new int[cols];
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                sums[col] += matrix[row, col];
            }
        }

        // Printing sums:
        foreach (var col in sums)
        {
            Console.WriteLine(col);
        }
    }
}