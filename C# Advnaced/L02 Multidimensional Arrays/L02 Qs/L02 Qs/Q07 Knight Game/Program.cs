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

        // X = currentRowIndex, Y = currentColIndex & Battles = List<Coordinates> that it battles
        var collisionDetected = new List<Coordinates>();

        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                bool isKnight = board[row, col] == 'K';
                if (isKnight)
                {
                    // Find out how many collisions:
                    // compare which has the most, delete it and start cycle again:
                    var currentKnight = new Coordinates()
                    {
                        X = row,
                        Y = col,
                        Battles = FindCollisions(board, size, row, col)
                    };
                }
            }
        }
    }
    public static List<Coordinates> FindCollisions(char[,] board, int size, int row, int col)
    {
        // shove all possible collisions to cycle through them easier:
        var possibleKnights = new List<Coordinates>();

        // 1st collision: row - 2, col - 1
        var coordinateOne = new Coordinates { X = row - 2, Y = col - 1 };
        possibleKnights.Add(coordinateOne);

        // 2nd collision: row - 2, col + 1
        var coordinateTwo = new Coordinates { X = row - 2, Y = col + 1 };
        possibleKnights.Add(coordinateTwo);

        // 3rd collision: row - 1, col + 2
        var coordinateThree = new Coordinates { X = row - 1, Y = col + 2 };
        possibleKnights.Add(coordinateThree);

        // 4th collision: row + 1, col + 2
        var coordinateFour = new Coordinates { X = row + 1, Y = col + 2 };
        possibleKnights.Add(coordinateFour);

        // 5th collision: row + 2, col + 1
        var coordinateFive = new Coordinates { X = row + 2, Y = col + 1 };
        possibleKnights.Add(coordinateFive);

        // 6th collision: row + 2, col - 2
        var coordinateSix = new Coordinates { X = row + 2, Y = col - 2 };
        possibleKnights.Add(coordinateSix);

        // 7th collision: row + 1, col - 2
        var coordinateSeven = new Coordinates { X = row + 1, Y = col - 2 };
        possibleKnights.Add(coordinateSeven);

        // 8th collision: row - 1, col - 2
        var coordinateEight = new Coordinates { X = row - 1, Y = col - 2 };
        possibleKnights.Add(coordinateEight);

        // Make a collection for the actual battles, which the method will return;
        var battles = new List<Coordinates>();

        // Cycle and check if valid, then check if knight and if all pass, then add to .Battles of currentCoor:
        foreach (var coor in possibleKnights)
        {
            bool battlesFound = FindBattles(board, size, coor);
            if (battlesFound)
            {
                battles.Add(new Coordinates { X = coor.X, Y = coor.Y });
            }
        }

        return battles;
    }

    public static bool FindBattles(char[,] board, int size, Coordinates coor)
    {
        bool battlesFound = false;

        var row = coor.X;
        var col = coor.Y;

        bool validIndex = CheckIndex(board, size, row, col);
        if (validIndex)
        {
            // check if point contains a knight:
            bool isKnight = board[row, col] == 'K';
            if (isKnight)
            {
                battlesFound = true;
            }
        }

        return battlesFound;
    }
    public static bool CheckIndex(char[,] board, int size, int row, int col) // Check the index:
    {
        bool validRow = row >= 0 && row < size;
        bool validCol = col >= 0 && col < size;

        bool validIndex = validRow && validCol;

        return validIndex;
    }
}