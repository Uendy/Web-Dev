using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // Reading parameter size:
        int size = int.Parse(Console.ReadLine());

        // Initialize matrix and begin reading elements and placing them in matrix:
        var matrix = new int[size, size];
        for (int rows = 0; rows < size; rows++)
        {
            var currentInput = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            for (int cols = 0; cols < currentInput.Count(); cols++)
            {
                matrix[rows, cols] = currentInput[cols];
            }
        }

        // Cycle matrix and sum diagonals:
        int sum = 0;
        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                bool diagonal = row == col;
                if (diagonal)
                {
                    sum += matrix[row, col];
                }
            }
        }

        // Printing sum:
        Console.WriteLine(sum);
    }
}