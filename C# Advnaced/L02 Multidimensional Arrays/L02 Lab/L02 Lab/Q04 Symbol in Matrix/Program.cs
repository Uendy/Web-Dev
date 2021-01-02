using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // Reading size parameters:
        var size = int.Parse(Console.ReadLine());

        // Initialize matrix, read row input and fill:
        var matrix = new char[size, size];
        for (int row = 0; row < size; row++)
        {
            var rowElements = Console.ReadLine().ToCharArray();
            for (int col = 0; col < size; col++)
            {
                matrix[row, col] = rowElements[col];
            }
        }

        // Read searched symbol and cycle matrix for it:
        var search = Console.ReadLine().First();
        for (int rows = 0; rows < size; rows++)
        {
            for (int cols = 0; cols < size; cols++)
            {
                var currentElement = matrix[rows, cols];
                bool found = currentElement == search;
                if (found)
                {
                    Console.WriteLine($"({rows}, {cols})");
                    return;
                }
            }
        }

        // If not found then print:
        Console.WriteLine($"{search} does not occur in the matrix");
    }
}