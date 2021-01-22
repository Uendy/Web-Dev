using System;
using System.IO;
public class Program
{
    public static void Main()
    {
        var reader = new StreamReader("input.txt");
        using (reader)
        {
            int index = 0;
            while (true)
            {
                var line = reader.ReadLine();

                if (line == null)
                {
                    break;
                }

                if (index % 2 != 0)
                {
                    Console.WriteLine(line);
                }

                index++;
            }
        }
    }
}