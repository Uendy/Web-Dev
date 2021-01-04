using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // Reading size of the matrix:
        var size = int.Parse(Console.ReadLine());

        // initialize and read matrix:
        var matrix = new int[size, size];
        for (int row = 0; row < size; row++)
        {
            var rowElements = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            for (int col = 0; col < size; col++)
            {
                matrix[row, col] = rowElements[col];
            }
        }

        // Find primary diagonal: [0,0], [1,1], [2,2]
        var primaryDiag = 0;
        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                bool diagonal = row == col;
                if (diagonal)
                {
                    primaryDiag += matrix[row, col];
                }
            }
        }

        // Find secondary diagonal: [0,2], [1,1], [2, 0]
        var secondaryDiag = 0;
        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                bool diagonal = row + col == size - 1;
                if (diagonal)
                {
                    secondaryDiag += matrix[row, col];
                }
            }
        }

        // Find absolute diagonal difference and print:
        Console.WriteLine(Math.Abs(primaryDiag - secondaryDiag));
    }
}