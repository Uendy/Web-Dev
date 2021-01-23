using System.Linq;
using System.IO;
class Program
{
    static void Main()
    {
        var firstFileLines = File.ReadAllLines(@"..\..\Input1.txt");
        var secondFileLines = File.ReadAllLines(@"..\..\Input2.txt");

        // This only work if both input files have the same amount of lines!
        for (int i = 0; i < firstFileLines.Count(); i++)
        {
            File.AppendAllText(@"..\..\Output.txt", $"{firstFileLines[i]}\n");
            File.AppendAllText(@"..\..\Output.txt", $"{secondFileLines[i]}\n");
        }
        
    }
}