using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // Initialize nested dict: <key = color, value = dict<key = clothing type, value = count>>
        var wardrobe = new Dictionary<string, Dictionary<string, int>>();

        // Readign inputCount:
        var inputCount = int.Parse(Console.ReadLine());

        // Reading inputs and updating wardrobe:
        for (int i = 0; i < inputCount; i++)
        {
            // Reading inputs:
            var input = Console.ReadLine().Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var color = input[0];
            var clothes = input[1].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            // Checking and updating wardrobe where needed:
            bool newColor = !wardrobe.ContainsKey(color);
            if (newColor)
            {
                wardrobe[color] = new Dictionary<string, int>();
            }

            foreach (var article in clothes)
            {
                bool newClohtes = !wardrobe[color].ContainsKey(article);
                if(newClohtes)
                {
                    wardrobe[color][article] = 0;
                }
                wardrobe[color][article]++;
            }
        }

        // Looking for specific color and article in wardrobe and print:
        var search = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        var searchedColor = search[0];
        var searchedClothing = search[1];

        foreach (var clothes in wardrobe)
        {
            Console.WriteLine($"{clothes.Key} clothes:");
            foreach (var article in wardrobe[clothes.Key])
            {
                bool found = clothes.Key == searchedColor  && article.Key == searchedClothing;
                if (found)
                {
                    Console.WriteLine($"* {article.Key} - {article.Value} (found!)");
                }
                else
                {
                    Console.WriteLine($"* {article.Key} - {article.Value}");
                }
            }
        }
    }
}