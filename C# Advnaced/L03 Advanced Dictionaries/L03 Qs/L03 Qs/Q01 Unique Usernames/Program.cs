using System;
using System.Collections.Generic;
public class Program
{
    public static void Main()
    {
        // Initialize Hashset:
        var usernames = new HashSet<string>();

        // Reading inputs and updating HashSet:
        var inputCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < inputCount; i++)
        {
            usernames.Add(Console.ReadLine());
        }

        // Printing each unique username:
        foreach (var username in usernames)
        {
            Console.WriteLine(username);
        }
    }
}