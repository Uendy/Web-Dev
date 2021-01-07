using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // Reading matrix parameters:
        var parameters = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        var rows = parameters[0];
        var cols = parameters[1];

        // Read snake, initialize snakeQueue and matrix:
        var snake = Console.ReadLine();
        var snakeQueue = new Queue<char>(snake.ToCharArray());
        var matrix = new char[rows][];

        // Begin filling matrix:
        for (int row = 0; row < rows; row++)
        {
            matrix[row] = new char[cols];
            for (int col = 0; col < cols; col++)
            {
                if (row % 2 == 0)
                {
                    matrix[row][col] = QueueSnake(snakeQueue);
                }

                else if (row % 2 != 0)
                {
                    for (int backwardsCol = cols - 1; backwardsCol >= 0; backwardsCol--)
                    {
                        matrix[row][backwardsCol] = QueueSnake(snakeQueue);
                    }
                    break;
                }
            }
        }
        // Printing matrix:
        foreach (var row in matrix)
        {
            Console.WriteLine(string.Join("", row));
        }
    }
    public static char QueueSnake(Queue<char> snakeQueue)
    {
        var currentChar = snakeQueue.Dequeue();
        snakeQueue.Enqueue(currentChar);

        return currentChar;
    }
}