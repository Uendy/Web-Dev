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
            matrix[size] = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries ).Select(int.Parse).ToArray();
        }

        // Read bomb coordinates:
        var bombsInput = Console.ReadLine().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        // Find all bombs and explode them:
        for (int bomb = 0; bomb < bombsInput.Count() / 2; bomb++)
        {
            int bombRow = bombsInput[bomb];
            int bombCol = bombsInput[bomb];

            matrix = Detonate(matrix, bombRow, bombCol, size);
        }
    }

    public static int[][] Detonate(int[][] matrix, int bombRow, int bombCol, int size)
    {
        bool validIndex = CheckIndex(bombRow, bombCol, size);
        if (validIndex)
        {

        }

        return matrix;
    }

    public static bool CheckIndex(int bombRow, int bombCol, int size)
    {
        throw new NotImplementedException();
    }
}