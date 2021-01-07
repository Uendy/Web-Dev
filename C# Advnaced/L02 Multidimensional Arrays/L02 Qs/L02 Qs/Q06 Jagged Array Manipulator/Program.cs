using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // Reading rows of jarr:
        var rows = int.Parse(Console.ReadLine());

        // Intialize jarr and fill:
        var jarr = new double[rows][];
        for (int row = 0; row < rows; row++)
        {
            jarr[row] = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
        }

        // Compare row counts, if they match, multiply both row's elements * 2, if not then divide both row's elements by 2
        for (int row = 0; row < rows - 1; row++)
        {
            var nextRow = row + 1;
            bool sameSize = jarr[row].Count() == jarr[nextRow].Count();
            if (sameSize)
            {
                jarr[row] = jarr[row].Select(x => x * 2).ToArray();
                jarr[row + 1] = jarr[row + 1].Select(x => x * 2).ToArray();
            }
            else // different sizes, so divide by two
            {
                jarr[row] = jarr[row].Select(x => x / 2).ToArray();
                jarr[row + 1] = jarr[row + 1].Select(x => x / 2).ToArray();
            }
        }

        // begin reading commands:
        var input = Console.ReadLine();
        while (input != "End")
        {
            var commandElements = input.Split(' ').ToArray();
            var command = commandElements[0];

            switch (command)
            {
                case "Add":
                    jarr = AddValue(jarr, commandElements);
                    break;

                case "Subtract":
                    jarr = SubtractValue(jarr, commandElements);
                    break;
            }
            // continue reading input:
            input = Console.ReadLine();
        }

        // Print jarr:
        foreach (var row in jarr)
        {
            Console.WriteLine(string.Join(" ", row));
        }
    }
    public static double[][] AddValue(double[][] jarr, string[] commandElements)
    {
        var row = int.Parse(commandElements[1]);
        var col = int.Parse(commandElements[2]);
        var value = int.Parse(commandElements[3]);

        bool validIndex = CheckIndex(row, col, jarr);
        if (validIndex)
        {
            jarr[row][col] += value;
        }
        return jarr;
    }
    public static double[][] SubtractValue(double[][] jarr, string[] commandElements)
    {
        var row = int.Parse(commandElements[1]);
        var col = int.Parse(commandElements[2]);
        var value = int.Parse(commandElements[3]);

        bool validIndex = CheckIndex(row, col, jarr);
        if (validIndex)
        {
            jarr[row][col] -= value;
        }
        return jarr;
    }
    public static bool CheckIndex(int row, int col, double[][] jarr)
    {
        bool validIndex = (row >= 0&& row < jarr.Count())  
            && (col >= 0 && col < jarr[row].Count());
        return validIndex;
    }
}