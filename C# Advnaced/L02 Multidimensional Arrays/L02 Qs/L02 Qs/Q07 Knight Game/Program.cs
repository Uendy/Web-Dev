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
                board[row, col] = currentRow[col];
            }
        }

        // Need to cycle board, and find all K's, then make a method for seeing if it attacks knights,
        // and to find a way to see which of the two knights is more dangerous and remove that one (looking for minimum knights to be removes)

        // key = array with row, col (coordinates), int = number of collisions it has:
        var collisionDetected = new Dictionary<int[], int>();

        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                bool isKnight = board[row, col] == 'K';
                if (isKnight)
                {
                    // Find out how many collisions:
                    // compare which has the most, delete it and start cycle again:
                    var collisions = FindCollisions(board, size, row, col);





                }
            }
        }
    }
    public static int FindCollisions(char[,] board, int size, int row, int col)
    {
        int collisions = 0;

        // shove all possible collisions to cycle through them easier:
        var possibleKnights = new List<Coordinates>();

        // 1st collision: row - 2, col - 1
        var coordinateOne = new Coordinates { X = row - 2, Y = col - 1 };
        possibleKnights.Add(coordinateOne);

        // 2nd collision: row - 2, col + 1
        var coordinateTwo = new Coordinates { X = row - 2, Y = col + 1 };
        possibleKnights.Add(coordinateTwo);

        // 3rd collision: row - 1, col + 2
        var coordinateTwo = new Coordinates { X = row - 2, Y = col + 1 };
        possibleKnights.Add(coordinateTwo);

        // 4th collision: row + 1, col + 2
        var coordinateTwo = new Coordinates { X = row - 2, Y = col + 1 };
        possibleKnights.Add(coordinateOne);

        // 5th collision: row + 2, col + 1
        var coordinateTwo = new Coordinates { X = row - 2, Y = col + 1 };
        possibleKnights.Add(coordinateOne);

        // 6th collision: row + 2, col - 2
        var coordinateTwo = new Coordinates { X = row - 2, Y = col + 1 };
        possibleKnights.Add(coordinateOne);

        // 7th collision: row + 1, col - 2
        var coordinateTwo = new Coordinates { X = row - 2, Y = col + 1 };
        possibleKnights.Add(coordinateOne);

        // 8th collision: row - 1, col - 2
        var coordinateTwo = new Coordinates { X = row - 2, Y = col + 1 };
        possibleKnights.Add(coordinateOne);

        bool validIndex = CheckIndex(board, size, row, col);

        return collisions;
    }
}