using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        var guests = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();

        

        string line;
        while ((line = Console.ReadLine()) != "Party")
        {
            var inputTokens = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = inputTokens[1];
            string predicate = inputTokens[2];
            
            Func<string, bool> Function = ManipulateGuestList(command, predicate);
        }
    }

    public static Func<string, bool> ManipulateGuestList(string command, string predicate)
    {
        switch (command)
        {
            case "StartsWith":
                return x => x.Where(x.First() == "predicate");
                    break;

            case "EndsWith":

                break;

            case "Length":

                break;

            default:
                break;
        }
    }
}