using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        var guests = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();

        string line;
        while ((line = Console.ReadLine()) != "Party!")
        {
            var inputTokens = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var command = inputTokens[0];
            var filter = inputTokens[1];
            var predicate = inputTokens[2];

            ManipulateGuestList(guests, command, filter, predicate);
        }

        if (guests.Any())
        {
            Console.WriteLine($"{ string.Join(" ", guests.OrderBy(x => x))} are going to the party!");
        }
        else
        {
            Console.WriteLine("Nobody is going to the party!");
        }
    }

    public static void ManipulateGuestList(List<string> guests, string command, string filter, string predicate)
    {
        switch (filter)
        {
            case "StartsWith":
                ForeachName(command, guests, n => n.StartsWith(predicate));
                break;
            case "EndsWith":
                ForeachName(command, guests, n => n.EndsWith(predicate));
                break;
            case "Length":
                ForeachName(command, guests, n => n.Length == int.Parse(predicate));
                break;
            default:
                break;
        }
    }

    public static void ForeachName(string command, List<string> guests, Func<string, bool> condition)
    {
        for (int i = guests.Count - 1; i >= 0; i--)
        {
            if (condition(guests[i]))
            {
                switch (command)
                {
                    case "Remove":
                        guests.RemoveAt(i);
                        break;
                    case "Double":
                        guests.Add(guests[i]);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}