using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        var guests = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();

        var commands = new List<Func<string, bool>>();

        string input;
        while ((input = Console.ReadLine()) != "Print")
        {
            var inputTokens = input.Split(new string[] { " ", ";" }, StringSplitOptions.RemoveEmptyEntries).ToList();

            commands = ManipulateCommands(inputTokens, commands);

        }
    }
    public static List<Func<string, bool>> ManipulateCommands(List<string> inputTokens, List<Func<string, bool>> commands)
    {
        var command = inputTokens[0];
        var filter = inputTokens[2];
        switch (filter)
        {

            default:
                break;
        }
        case "StartsWith":
                ForeachName(command, guests, n => n.StartsWith(predicate));
        break;
            case "EndsWith":
                ForeachName(command, guests, n => n.EndsWith(predicate));
        break;
            case "Length":
                ForeachName(command, guests, n => n.Length == int.Parse(predicate));
        break;

        return commands;
    }
}