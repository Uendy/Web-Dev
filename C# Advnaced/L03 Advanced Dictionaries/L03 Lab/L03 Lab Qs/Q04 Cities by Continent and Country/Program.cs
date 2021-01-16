using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // Reading inputCount
        var inputCount = int.Parse(Console.ReadLine());

        // Initialize dict: 
        var map = new Dictionary<string, Dictionary<string, List<string>>>(); // key = continent, value = Dict<key = country, value = list of cities>:

        // Read inputs and update dict:
        for (int i = 0; i < inputCount; i++)
        {
            var inputInfo = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var continent = inputInfo[0];
            var country = inputInfo[1];
            var city = inputInfo[2];

            // Begin updating dict:
            if (!map.ContainsKey(continent))
            {
                map[continent] = new Dictionary<string, List<string>>();
            }
            if (!map[continent].ContainsKey(country))
            {
                map[continent][country] = new List<string>();
            }

            map[continent][country].Add(city);
        }

        // Print map:
        foreach (var continent in map)
        {
            Console.WriteLine($"{continent.Key}: ");
            foreach (var country in continent.Value)
            {
                Console.WriteLine($"{country.Key} -> {string.Join(" ", country.Value)}");
            }
        }
    }
}