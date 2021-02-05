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

            ManipulateCommands(inputTokens, commands);
        }
    }
    public static void ManipulateCommands(List<string> inputTokens, List<Func<string, bool>> commands)
    {
        var command = inputTokens[0];
        var filter = inputTokens[2];
        string predicate;
        switch (filter)
        {
            case "Starts":
                predicate = inputTokens[5];
                ForeachName(command, filter, predicate, commands);
                break;
            case "Ends":
                predicate = inputTokens[5];
                ForeachName(command, filter, predicate, commands);
                break;
            case "Length": // does not conatin token: with, so it is 4th index and need to convert it to int
                predicate = inputTokens[4];
                ForeachName(command, filter, predicate, commands);
                break;

            case "Contains": // does not conatin token: with, so it is 4th index
                 predicate = inputTokens[4];
                ForeachName(command, filter, predicate, commands);
                break;
            default:
                break;
        }
    }

    public static void ForeachName(string command, string filter, string predicate, List<Func<string, bool>> commands)
    {
        if (command == "Add")
        {

        }
        else // Remove
        {
        
        }
    }
}