using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // Reading input and initialize queue:
        var queue = new Queue<string>(Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.None).ToList());

        // Read commands and execute:
        while (queue.Any())
        {
            var commandTokens = Console.ReadLine().Split(' ').ToList();
            string command = commandTokens[0];

            switch (command)
            {
                case "Play":
                    queue.Dequeue();
                    break;

                case "Add":
                    // get full song and check
                    string song = string.Join(" ", commandTokens.Skip(1));
                    bool newSong = !queue.Contains(song);
                    if (newSong)
                    {
                        queue.Enqueue(song);
                    }
                    else
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                    break;

                case "Show":
                    Console.WriteLine(string.Join(", ", queue));
                    break;
            }
        }

        // Print output:
        Console.WriteLine("No more songs!");
    }
}