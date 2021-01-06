using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // Reading input: parameters and snake:
        var parameters = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int rows = parameters[0];
        int cols = parameters[1];
        string snake = Console.ReadLine();
        var queueSnake = new Queue<char>(snake.ToArray());
        char[,] matrix = new char[rows, cols]; // create char matrix with rows and cols          

        // fill in the matrix with snake movements
        for (int row = 0; row < rows; row++) 
        {
            for (int col = 0; col < cols; col++)
            {
                if (row % 2 == 0)
                {
                    char currentSymbol = MoveTheSnake(queueSnake);
                    matrix[row, col] = currentSymbol;
                }

                else if (row % 2 != 0)
                {
                    for (int j = cols - 1; j >= 0; j--)
                    {
                        char currentSymbol = MoveTheSnake(queueSnake);
                        matrix[row, j] = currentSymbol;
                    }

                    break;
                }
            }
        }

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Console.Write(matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
    public static char MoveTheSnake(Queue<char> queueSnake)
    {
        char currentSymbol = queueSnake.Dequeue();
        queueSnake.Enqueue(currentSymbol);
        return currentSymbol;
    }
}