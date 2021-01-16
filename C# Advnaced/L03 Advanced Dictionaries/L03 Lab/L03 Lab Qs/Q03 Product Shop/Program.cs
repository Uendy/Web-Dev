using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // Initialize dicts:
        var catalogue = new SortedDictionary<string, Dictionary<string, double>>(); // Key = store name, Value = nestedDict: key = product, value = price

        // Begin reading input and updating dict:
        string input = Console.ReadLine();
        while (input != "Revision")
        {
            // Extracting info from input:
            var inputElements = input.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var shopName = inputElements[0];
            var productName = inputElements[1];
            var price = double.Parse(inputElements[2]);

            // Initializing new nested dict if the shop is new:
            bool newStore = !catalogue.ContainsKey(shopName);
            if (newStore)
            {
                catalogue[shopName] = new Dictionary<string, double>();
            }

            catalogue[shopName][productName] = price;

            // Continue reading input:
            input = Console.ReadLine();
        }

        // Print out shops and products: 
        foreach (var shop in catalogue)
        {
            Console.WriteLine($"{shop.Key}->");
            foreach (var item in shop.Value)
            {
                Console.WriteLine($"Product: {item.Key}, Price: {item.Value} ");
            }
        }
    }
}