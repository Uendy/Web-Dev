using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // Reading input about paramaters:
        var paramaters = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.None).Select(int.Parse).ToList();
        int rows = paramaters[0];
        int cols = paramaters[1];

        // Printing params:
        Console.WriteLine(rows);
        Console.WriteLine(cols);

        // Recreate matrix:
        var matrix = new int[rows, cols];
        for (int row = 0; row < rows; row++)
        {
            var currentRow = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.None).Select(int.Parse).ToList();
            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = currentRow[col];
            }
        }

        // Sum matrix:
        long sum = 0;
        foreach (var element in matrix)
        {
            sum += element;
        }

        // Printing sum:
        Console.WriteLine(sum);
    }
}