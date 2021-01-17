using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // Initialize HashSets for regular and VIP guests:
        var guestRegular = new HashSet<string>();
        var guestVIP = new HashSet<string>();

        // Begin reading command until party and adding them to subsequent list:
        string input = Console.ReadLine();
        while (input != "PARTY")
        {
            // find if guest is vip, first char is a digit
            bool isVIP = char.IsDigit(input.ToCharArray().First());
            if (isVIP)
            {
                guestVIP.Add(input);
            }
            else
            {
                guestRegular.Add(input);
            }

            // Continue reading:
            input = Console.ReadLine();
        }

        // Begin reading guests who came and checking them off the list
        input = Console.ReadLine();
        while (input != "END")
        {
            if (guestRegular.Contains(input))
            {
                guestRegular.Remove(input);
            }
            else
            {
                guestVIP.Remove(input);
            }

            // Continue reading:
            input = Console.ReadLine();
        }


        // Find total of guests, who didn't come and print VIPs then regulars:
        var missingGuests = guestRegular.Count() + guestVIP.Count();
        Console.WriteLine(missingGuests);

        foreach (var guest in guestVIP)
        {
            Console.WriteLine(guest);
        }
        foreach (var guest in guestRegular)
        {
            Console.WriteLine(guest);
        }
    }
}