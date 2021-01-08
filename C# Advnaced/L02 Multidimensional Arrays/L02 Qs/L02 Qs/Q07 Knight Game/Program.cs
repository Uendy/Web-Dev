using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // Reading size parameters:
        var size = int.Parse(Console.ReadLine());

        // Initialize and fill matrix:
        var board = new char[size, size];
        for (int row = 0; row < size; row++)
        { 
            var currentRow = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
            for (int col = 0; col < size; col++)
            {
                board[row,col] = currentRow[col];
            }
        }

        // Need to cycle board, and find all K's, then make a method for seeing if it attacks knights,
        // and to find a way to see which of the two knights is more dangerous and remove that one (looking for minimum knights to be removes)
    }
}