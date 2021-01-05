using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // Reading size of matrix:
        var size = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        var rows = size[0];
        var cols = size[1];

        // Initializing matrix and fill:
        var matrix = new string[rows, cols];
        for (int row = 0; row < rows; row++)
        {
            var rowElements = Console.ReadLine().Split(' ');
            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = rowElements[col];
            }
        }

        // Find how many equal squares there are:
        int squares = 0;
        for (int row = 0; row < rows-1; row++)
        {
            for (int col = 0; col < cols-1; col++)
            {
                // Get all chars in current square:
                var currentChar = matrix[row, col];
                var aboveChar = matrix[row + 1, col];
                var rightChar = matrix[row, col + 1];
                var diagChar = matrix[row + 1, col + 1];

                bool isSquare = 
                    currentChar == aboveChar &&
                    aboveChar == rightChar &&
                    rightChar== diagChar;
                if (isSquare)
                {
                    squares++;
                }
            }
        }

        // Printing number of squares:
        Console.WriteLine(squares);
    }
}