using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        var guests = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();

        var commands = new List<string>();

        string input;
        while ((input = Console.ReadLine()) != "Print")
        {
            var inputTokens = input.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var command = inputTokens[0];
            var filter = inputTokens[1];
            var predicate = inputTokens[2];

            if (command == "Add filter")
            {
                commands.Add($"{filter} {predicate}");
            }
            else // Remove
            {
                commands.Remove($"{filter} {predicate}");
            }
        }

        foreach (var command in commands)
        {
            var commandTokens = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();

            // Doing this to not mess up my predicate index (ex: Starts with;P  or Length;6)
            if (commandTokens.Contains("with"))
            {
                commandTokens.Remove("with");
            }

            var filter = commandTokens[0];
            var predicate = commandTokens[1];
            switch (filter)
            {
                case "Starts":
                    guests = guests.Where(x => !x.StartsWith(predicate)).ToList();
                    break;

                case "Ends":
                    guests = guests.Where(x => !x.EndsWith(predicate)).ToList();
                    break;

                case "Contains":
                    guests = guests.Where(x => !x.Contains(predicate)).ToList();
                    break;

                case "Length":
                    guests = guests.Where(x => x.Length != int.Parse(predicate)).ToList();
                    break;

                default:
                    break;
            }
        }

        if (guests.Any())
        {
            Console.WriteLine(string.Join(" ", guests));
        }
        else 
        {
            Console.WriteLine("No guests left!");
        }
    }
}