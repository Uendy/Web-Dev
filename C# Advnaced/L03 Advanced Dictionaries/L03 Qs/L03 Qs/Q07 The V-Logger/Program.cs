using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // Initialize data structure: // Wont be using dicts
        var users = new List<Vlogger>();

        // Begin reading the input and updating users:
        string input = Console.ReadLine();
        while (input != "Statistics")
        {
            // Reading input elements:
            var inputElements = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            var userName = inputElements[0];
            var command = inputElements[1];

            switch (command)
            {
                case "joined":
                    // Check if user is already added:
                    bool newUser = !users.Any(x => x.Name == userName);
                    if (newUser)
                    {
                        users.Add(new Vlogger { Name = userName, 
                            Followers = new HashSet<string>(), 
                            Following = new HashSet<string>() 
                        });
                    }
                    break;

                case "followed":
                    // Check if users are valid:
                    var followedUser = inputElements[2];
                    bool followerExists = users.Any(x => x.Name == userName);
                    if (followerExists)
                    {
                        bool followedUserExists = users.Any(x => x.Name == followedUser);
                        if (followedUserExists)
                        {
                            bool differentUsers = userName != followedUser;
                            if (differentUsers)
                            {
                                // Update users with a follower and a followee
                                users.Find(x => x.Name == userName).Following.Add(followedUser);
                                users.Find(x => x.Name == followedUser).Followers.Add(userName);
                            }
                        }
                    }
                    break;
                default:
                    break;
            }

            // Continue reading input:
            input = Console.ReadLine();
        }

        // Print out all vloggers in their proper order:
        Console.WriteLine($"The V-Logger has a total of {users.Count()} vloggers in its logs.");
        users = users.OrderByDescending(x => x.Followers.Count()).ThenBy(x => x.Following.Count()).ToList();

        // Print the most famous user's stats:
        var mostFamous = users.First();
        Console.WriteLine($"1. {mostFamous.Name} : {mostFamous.Followers.Count()} followers, {mostFamous.Following.Count()} following");
        foreach (var follower in mostFamous.Followers.OrderBy(x => x))
        {
            Console.WriteLine($"*  {follower}");
        }
        users.Remove(mostFamous);

        // Print remaining users:
        var rank = 2; // used to incrament users in foreach cycle:
        foreach (var user in users)
        {
            Console.WriteLine($"{rank}. {user.Name} : {user.Followers.Count()} followers, {user.Following.Count()} following");
            rank++;
        }
    }
}