using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // Intialize contests dict:
        var contests = new Dictionary<string, string>();

        // Reading contests:
        string input;
        while ((input = Console.ReadLine()) != "end of contests")
        {
            // Getting inputInfo:
            var inputElements = input.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var contest = inputElements[0];
            var password = inputElements[1];

            bool newContest = !contests.ContainsKey(contest);
            if(newContest)
            {
                contests[contest] = password;
            }
        }

        // Intialize users: 
        var users = new Dictionary<string, Dictionary<string, int>>(); // Key = username, Value = Dict<contest, point>

        // Read contestants: "{contest}=>{password}=>{username}=>{points}"
        while ((input = Console.ReadLine()) != "end of submissions")
        {
            // Getting inputInfo:
            var inputElements = input.Split(new string[] { "=>" }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var contest = inputElements[0];
            var password = inputElements[1];
            var username = inputElements[2];
            var points = int.Parse(inputElements[3]);

            // Checks:
            bool contestExists = contests.ContainsKey(contest); // Validity of contest
            if (contestExists)
            {
                bool rightPassword = contests[contest] == password; // validity of password
                if (rightPassword)
                {
                    bool newUser = !users.ContainsKey(username); // Adding user if needed
                    if (newUser)
                    {
                        users[username] = new Dictionary<string, int>();
                    }

                    bool newContestForUser = !users[username].ContainsKey(contest); // Adding contest for used if needed
                    if (newContestForUser)
                    {
                        users[username][contest] = 0;
                    }

                    bool newHighScore = users[username][contest] < points; // Checking to see if updated score is needed
                    if (newHighScore)
                    {
                        users[username][contest] = points;
                    }
                }
            }
        }

        // Printing top user:
        var topUser = users.OrderByDescending(x => x.Value.Values.Sum()).First();
        Console.WriteLine($"Best candidate is {topUser.Key} with total {topUser.Value.Values.Sum()} points.");

        // Printing ordered users:
        Console.WriteLine("Ranking:");
        users = users.OrderBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);
        foreach (var user in users.Keys)
        {
            Console.WriteLine(user);
            var currentUser = users[user].OrderByDescending(x => x.Value);
            foreach (var contest in currentUser)
            {
                Console.WriteLine($"# {contest.Key} -> {contest.Value}");
            }
        }
    }
}