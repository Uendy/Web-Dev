using System;
public class Program
{
    public static void Main()
    {
        // Reading number of rows:
        var rows = int.Parse(Console.ReadLine());

        // initalize jaggedArray:
        var jarr = new long[rows][];

        for (int row = 0; row < rows; row++)
        {
            jarr[row] = new long[row + 1];
        }
        jarr[0][0] = 1;

        // Fill in all other by having it sum the number above and the number to the left of the above:
        for (int row = 1; row < rows; row++)
        {
            var currentRow = jarr[row];
            for (int col = 0; col < currentRow.Length; col++)
            {
                bool isEdge = col == 0 || col == currentRow.Length - 1;
                if (isEdge)
                {
                    jarr[row][col] = 1;
                }
                else // need to use algorythm
                {
                    var above = jarr[row - 1][col];
                    var left = jarr[row - 1][col - 1];
                    var newSum = above + left;
                    jarr[row][col] = newSum;
                }
            }
        }

        // Printing jarr:
        foreach (var row in jarr)
        {
            Console.WriteLine(string.Join(" ", row));
        }
    }
}