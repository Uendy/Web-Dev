using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        int greenTime = int.Parse(Console.ReadLine());
        int freeTime = int.Parse(Console.ReadLine());

        var line = new Queue<string>();

        int carsPassed = 0;

        while (true)
        {
            int green = greenTime;
            int free = freeTime;

            string input = Console.ReadLine();
            if (input == "END")
            {
                // If all passed then write success and how many cars passed:
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{carsPassed} total cars passed the crossroads.");
                return;
            }
            else if (input == "green")
            {
                while (line.Any() && green > 0)
                {
                    string car = line.Dequeue();
                    var carLength = car.Length;
                    
                    green -= carLength;
                    if (green > 0)  // car passes okay
                    {
                        carsPassed++;
                    }
                    else // need to see if car will pass with freeTime, or there will be a crash
                    {
                        free += green;
                        if (free > 0) // it passes, since green is 0 it wont let the next car through;
                        {
                            carsPassed++;
                        }
                        else // crash happened!
                        {
                            char crashChar = car[carLength + free];
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{car} was hit at {crashChar}.");
                            return;
                        }
                    }
                }
            }
            else // Add car to queue:
            {
                line.Enqueue(input);
            }
        }
    }
}