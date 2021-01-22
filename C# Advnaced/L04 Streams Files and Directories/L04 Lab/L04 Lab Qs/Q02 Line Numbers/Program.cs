using System.IO;
public class Program
{
    public static void Main()
    {
        var reader = new StreamReader("input.txt");

        int count = 1;
        using (reader)
        {
            var line = reader.ReadLine();

            var writer = new StreamWriter(".\\output.txt");
            using (writer)
            {
                while (line != null)
                {
                    var numberedLine = $"{count}. {line}";
                    writer.WriteLine(numberedLine);
                    line = reader.ReadLine();
                    count++;
                }
            }
        }
    }
}