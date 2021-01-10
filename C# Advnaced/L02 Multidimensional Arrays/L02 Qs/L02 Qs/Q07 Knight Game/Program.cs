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
            var currentRow = Console.ReadLine().ToCharArray();
            for (int col = 0; col < size; col++)
            {
                board[row, col] = currentRow[col];
            }
        }

        // Need to cycle board, and find all K's, then make a method for seeing if it attacks knights,
        var battleLog = new List<Coordinates>(); // X = currentRowIndex, Y = currentColIndex & Battles = List<Coordinates> that it battles

        // Cycle through whole matrix and find for each Knight its position (coordinates X, Y) and battles
        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                bool isKnight = board[row, col] == 'K';
                if (isKnight)
                {
                    // Find out how many collisions:
                    var currentKnight = new Coordinates()
                    {
                        X = row,
                        Y = col,
                        Battles = FindCollisions(board, size, row, col)
                    };

                    // If there are collisions add it to battleLog, if not the Knight is harmless, do nothing
                    bool collisionsFound = currentKnight.Battles.Count() > 0;
                    if (collisionsFound)
                    {
                        battleLog.Add(currentKnight);
                    }
                }
            }
        }

        // Find which Knight has the most collisions:
        // Remove him and cycle through all knight who have a collision with him and remove it
        // Cycle until there is no knight with collisions:
        var knightsRemoved = 0;

        bool battlesRemaining = battleLog.Any(x => x.Battles.Count() > 0);
        while (battlesRemaining)
        {
            // Find the most dangerous:
            var mostDangerousKnight = battleLog.OrderByDescending(x => x.Battles.Count()).First();

            // Remove it from the list of all other Knights who have battles with it:
            battleLog = RemoveKnight(battleLog, mostDangerousKnight);

            // Remove it from battleLog:
            battleLog.Remove(battleLog.OrderBy(x => x.Battles.Count()).First());
            knightsRemoved++;

            // Continue reading battles:
            battlesRemaining = battleLog.Any(x => x.Battles.Count() > 0);
        }

        // Print the knightsRemoved:
        Console.WriteLine(knightsRemoved);
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

        // 6th collision: row + 2, col - 1
        var coordinateSix = new Coordinates { X = row + 2, Y = col - 1 };
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

        bool validIndex = CheckIndex(size, row, col);
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
    public static bool CheckIndex(int size, int row, int col) // Check the index:
    {
        bool validRow = row >= 0 && row < size;
        bool validCol = col >= 0 && col < size;

        bool validIndex = validRow && validCol;

        return validIndex;
    }
    public static List<Coordinates> RemoveKnight(List<Coordinates> battleLog, Coordinates mostDangerousKnight)
    {
        // Get info on the danger knight, X, Y, Battles
        var battles = mostDangerousKnight.Battles;
        var dangerCoordinates = new Coordinates()
        {
            X = mostDangerousKnight.X,
            Y = mostDangerousKnight.Y
        };

        // cycle through dangerousKnight's battle and remove it from the battleLog.Battles of other knights:
        foreach (var battle in battles)
        {
            // Cyle through the knights in battleLog and see which have battles with dangerKnight
            foreach (var knight in battleLog)
            {
                foreach (var fight in knight.Battles)
                {
                    bool fightFound = fight.X == dangerCoordinates.X && fight.Y == dangerCoordinates.Y;
                    if (fightFound)
                    {
                        knight.Battles.Remove(fight);
                        break;
                    }
                }
            }
        }

        return battleLog;
    }
}