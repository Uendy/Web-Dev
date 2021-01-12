using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // Reading input parameters:
        var size = int.Parse(Console.ReadLine());
        var commands = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();

        // Initialize and fill matrix, while keeping track of start point and total coals:
        var currentRow = -1; 
        var currentCol = -1;
        var coalRemaining = 0;

        var matrix = new char[size,size];
        for (int row = 0; row < size; row++)
        {
            var currentRowElements = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
            for (int col = 0; col < size; col++)
            {
                matrix[row,col] = currentRowElements[col];

                bool isCoal = currentRowElements[col] == 'c';
                if (isCoal)
                {
                    coalRemaining++;
                }

                bool isStart = currentRowElements[col] == 's';
                if (isStart)
                {
                    currentRow = row;
                    currentCol = col;
                }
            }
        }

        // Begin executing commands:
        while (commands.Any())
        {
            // Move:
            var newRow = currentRow;
            var newCol = currentCol;

            var move = commands[0];
            switch (move)
            {
                case "up":
                    newRow -= 1;
                    break;

                case "right":
                    newCol += 1;
                    break;

                case "down":
                    newRow += 1;
                    break;

                case "left":
                    newCol -= 1;
                    break;
                default:
                    break;
            }

            // if invalid inded, skip command
            bool validIndex = newRow >= 0 && newRow < size
                && newCol >= 0 && newCol < size;
            if (validIndex)
            {
                // Update: row and col:
                currentRow = newRow;
                currentCol = newCol;

                // if coal: pick it up and replace with '*'
                bool foundCoal = matrix[currentRow, currentCol] == 'c';
                if (foundCoal)
                {
                    matrix[currentRow, currentCol] = '*';
                    coalRemaining--;
                    
                    // if no more coal print and end program
                    bool noMoreCoal = coalRemaining == 0;
                    if (noMoreCoal)
                    {
                        Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                        return;
                    }
                }
                
                // check if you reached end 'e', print and end the program
                bool foundEnd = matrix[currentRow, currentCol] == 'e';
                if (foundEnd)
                {
                    Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                    return;
                }
            }
            // Next command:
            commands.RemoveAt(0);
        }

        // If no more commands: print and end program:
        Console.WriteLine($"{coalRemaining} coals left. ({currentRow}, {currentCol})");
    }
}