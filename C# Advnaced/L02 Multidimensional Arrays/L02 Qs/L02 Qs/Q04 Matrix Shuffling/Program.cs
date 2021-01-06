using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // Reading matrix parameters:
        var parameters = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        var rows = parameters[0];
        var cols = parameters[1];

        // Initialize and fill matrix:
        var matrix = new string[rows][];
        for (int row = 0; row < rows; row++)
        {
            matrix[row] = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        }

        // Read swap commands and update matrix:
        var command = Console.ReadLine();
        while (command != "END")
        {
            // Get coordinates:
            var commandElements = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            // Check validity of input:
            bool validInput = commandElements[0] == "swap" && commandElements.Count() == 5;
            if (!validInput)
            {
                command = Console.ReadLine();
                Console.WriteLine("Invalid input!");
                continue;
            }

            var firstRowIndex = int.Parse(commandElements[1]);
            var firstColIndex = int.Parse(commandElements[2]);
            var secondRowIndex = int.Parse(commandElements[3]);
            var secondColIndex = int.Parse(commandElements[4]);

            // Check validity of these index:
            bool validIndex = firstColIndex >= 0 && firstColIndex < rows
                && firstColIndex >= 0 && firstColIndex < cols
                && secondRowIndex >= 0 && secondRowIndex < rows
                && secondColIndex >= 0 && secondColIndex < cols;
            if (validIndex) // Update matrix:
            {
                var temporary = matrix[secondRowIndex][secondColIndex];
                matrix[secondRowIndex][secondColIndex] = matrix[firstRowIndex][firstColIndex];
                matrix[firstRowIndex][firstColIndex] = temporary;
                
                // Print updated matrix:
                foreach (var row in matrix)
                {
                    Console.WriteLine(string.Join(" ", row));
                }
            }
            else // Return invalid 
            {
                Console.WriteLine("Invalid input!");
            }

            // Continue reading commands:
            command = Console.ReadLine();
        }
    }
}