using System;
using System.Linq;
using System.IO;
public class Program
{
    public static void Main()
    {
        var reader = new FileStream(@"..\..\input.txt", FileMode.OpenOrCreate);
        using (reader)
        {
            var parts = 4;

            // In case the number isn't divisable by parts, loosing data
            var length = (int)Math.Ceiling(reader.Length / (decimal)parts);

            var buffer = new byte[length];

            for (int i = 0; i < parts; i++)
            {
                var bytesRead = reader.Read(buffer, 0, buffer.Length);

                // In case the number isn't divisable by parts
                if (bytesRead < buffer.Length)
                {
                    buffer = buffer.Take(bytesRead).ToArray();
                }

                var writer = new FileStream($@"..\..\Part{i + 1}.txt", FileMode.OpenOrCreate);
                using (writer)
                {
                    writer.Write(buffer, 0, buffer.Length);
                }
            }
        }
    }
}