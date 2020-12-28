using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // Reading time and initializing queue:
        int greenTime = int.Parse(Console.ReadLine());
        int green = greenTime;
        int freeTime = int.Parse(Console.ReadLine());
        int free = freeTime;

        var line = new Queue<string>();

        int carsPassed = 0;

        string input = Console.ReadLine();
        while (input != "END")
        {
            if (input == "green") // reset the time we have
            {
                greenTime = green;
                freeTime = free;
            }
            else
            {
                line.Enqueue(input);

                // Begin releasing cars:
                while (line.Any() && greenTime != 0)
                {
                    int carLength = line.Peek().Length;

                    bool carCrosses = carLength <= greenTime;
                    if (carCrosses) // it passes safely
                    {
                        carsPassed++;
                        greenTime -= carLength;
                    }
                    else  // not enough greentime, try adding freetime:
                    {
                        int remainingTime = freeTime + greenTime;
                        if (carLength <= freeTime + greenTime)
                        {
                            carsPassed++;
                            greenTime = 0;
                            freeTime = remainingTime - carLength;
                        }
                        else // crash:
                        {
                            var car = line.Peek().ToArray();
                            char crashChar = car[remainingTime];
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{line.Peek()} was hit at {crashChar}.");
                            return;
                        }

                    }
                    line.Dequeue();
                }
            }
            // continue reading input:
            input = Console.ReadLine();
        }
        // If all passed then write success and how many cars passed:
        Console.WriteLine("Everyone is safe.");
        Console.WriteLine($"{carsPassed} total cars passed the crossroads.");
    }
}